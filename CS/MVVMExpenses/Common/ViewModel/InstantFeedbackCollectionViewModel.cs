using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataAnnotations;
using System.Collections.ObjectModel;
using DevExpress.Data.Linq;
using System.Collections;
using MVVMExpenses.Common.Utils;
using MVVMExpenses.Common.DataModel;

namespace MVVMExpenses.Common.ViewModel {
    public partial class InstantFeedbackCollectionViewModel<TEntity, TPrimaryKey, TUnitOfWork> : InstantFeedbackCollectionViewModelBase<TEntity, TEntity, TPrimaryKey, TUnitOfWork>
        where TEntity : class, new()
        where TUnitOfWork : IUnitOfWork {

        public static InstantFeedbackCollectionViewModel<TEntity, TPrimaryKey, TUnitOfWork> CreateInstantFeedbackCollectionViewModel(
            IUnitOfWorkFactory<TUnitOfWork> unitOfWorkFactory,
            Func<TUnitOfWork, IRepository<TEntity, TPrimaryKey>> getRepositoryFunc,			
			Func<IRepositoryQuery<TEntity>, IQueryable<TEntity>> projection = null,
			Func<bool> canCreateNewEntity = null) {
            return ViewModelSource.Create(() => new InstantFeedbackCollectionViewModel<TEntity, TPrimaryKey, TUnitOfWork>(unitOfWorkFactory, getRepositoryFunc, projection, canCreateNewEntity));
        }

        protected InstantFeedbackCollectionViewModel(
            IUnitOfWorkFactory<TUnitOfWork> unitOfWorkFactory,
            Func<TUnitOfWork, IRepository<TEntity, TPrimaryKey>> getRepositoryFunc,
			Func<IRepositoryQuery<TEntity>, IQueryable<TEntity>> projection = null,
			Func<bool> canCreateNewEntity = null)
            : base(unitOfWorkFactory, getRepositoryFunc, projection, canCreateNewEntity) {
        }
    }

	public partial class InstantFeedbackCollectionViewModel<TEntity, TProjection, TPrimaryKey, TUnitOfWork> : InstantFeedbackCollectionViewModelBase<TEntity, TProjection, TPrimaryKey, TUnitOfWork>
        where TEntity : class, new()
        where TProjection : class
        where TUnitOfWork : IUnitOfWork {

        public static InstantFeedbackCollectionViewModel<TEntity, TProjection, TPrimaryKey, TUnitOfWork> CreateInstantFeedbackCollectionViewModel(
            IUnitOfWorkFactory<TUnitOfWork> unitOfWorkFactory,
            Func<TUnitOfWork, IRepository<TEntity, TPrimaryKey>> getRepositoryFunc,
            Func<IRepositoryQuery<TEntity>, IQueryable<TProjection>> projection,
			Func<bool> canCreateNewEntity = null) {
            return ViewModelSource.Create(() => new InstantFeedbackCollectionViewModel<TEntity, TProjection, TPrimaryKey, TUnitOfWork>(unitOfWorkFactory, getRepositoryFunc, projection, canCreateNewEntity));
        }

        protected InstantFeedbackCollectionViewModel(
            IUnitOfWorkFactory<TUnitOfWork> unitOfWorkFactory,
            Func<TUnitOfWork, IRepository<TEntity, TPrimaryKey>> getRepositoryFunc,
            Func<IRepositoryQuery<TEntity>, IQueryable<TProjection>> projection,
			Func<bool> canCreateNewEntity = null)
			: base(unitOfWorkFactory, getRepositoryFunc, projection, canCreateNewEntity) {
        }
    }

    public abstract class InstantFeedbackCollectionViewModelBase<TEntity, TProjection, TPrimaryKey, TUnitOfWork> : IDocumentContent, ISupportLogicalLayout
        where TEntity : class, new()
        where TProjection : class
        where TUnitOfWork : IUnitOfWork {

        #region inner classes
        public class InstantFeedbackSourceViewModel : IListSource {
            public static InstantFeedbackSourceViewModel Create(Func<int> getCount, IInstantFeedbackSource<TProjection> source) {
                return ViewModelSource.Create(() => new InstantFeedbackSourceViewModel(getCount, source));
            }

            readonly Func<int> getCount;
            readonly IInstantFeedbackSource<TProjection> source;

            protected InstantFeedbackSourceViewModel(Func<int> getCount, IInstantFeedbackSource<TProjection> source) {
                this.getCount = getCount;
                this.source = source;
            }

            public int Count { get { return getCount(); } }

            public void Refresh() {
                source.Refresh();
                this.RaisePropertyChanged(x => x.Count);
            }

            bool IListSource.ContainsListCollection { get { return source.ContainsListCollection; } }

            IList IListSource.GetList() {
                return source.GetList();
            }
        }
        #endregion

        protected readonly IUnitOfWorkFactory<TUnitOfWork> unitOfWorkFactory;
        protected readonly Func<TUnitOfWork, IRepository<TEntity, TPrimaryKey>> getRepositoryFunc;
        protected Func<IRepositoryQuery<TEntity>, IQueryable<TProjection>> Projection { get; private set; }
		Func<bool> canCreateNewEntity;
        readonly IRepository<TEntity, TPrimaryKey> helperRepository;
        readonly IInstantFeedbackSource<TProjection> source;

        protected InstantFeedbackCollectionViewModelBase(
			IUnitOfWorkFactory<TUnitOfWork> unitOfWorkFactory, 
			Func<TUnitOfWork, IRepository<TEntity, TPrimaryKey>> getRepositoryFunc,
			Func<IRepositoryQuery<TEntity>, IQueryable<TProjection>> projection,
			Func<bool> canCreateNewEntity = null)
		{
            this.unitOfWorkFactory = unitOfWorkFactory;
			this.canCreateNewEntity = canCreateNewEntity;
            this.getRepositoryFunc = getRepositoryFunc;
            this.Projection = projection;
			this.helperRepository = CreateRepository();

            RepositoryExtensions.VerifyProjection(helperRepository, projection);

            this.source = unitOfWorkFactory.CreateInstantFeedbackSource(getRepositoryFunc, Projection);
            this.Entities = InstantFeedbackSourceViewModel.Create(() => helperRepository.Count(), source);

            if(!this.IsInDesignMode())
                OnInitializeInRuntime();
        }

        public InstantFeedbackSourceViewModel Entities { get; private set; }
        public virtual object SelectedEntity { get; set; }

        public virtual void New() {
			if (canCreateNewEntity != null && !canCreateNewEntity())
				return;
            DocumentManagerService.ShowNewEntityDocument<TEntity>(this);
        }

        public virtual void Edit(object threadSafeProxy) {
			if(!source.IsLoadedProxy(threadSafeProxy))
				return;
            TPrimaryKey primaryKey = GetProxyPrimaryKey(threadSafeProxy);
			TEntity entity = helperRepository.Find(primaryKey);
            if(entity == null) {
                DestroyDocument(DocumentManagerService.FindEntityDocument<TEntity, TPrimaryKey>(primaryKey));
                return;
            }
            DocumentManagerService.ShowExistingEntityDocument<TEntity, TPrimaryKey>(this, primaryKey);
        }

        public bool CanEdit(object threadSafeProxy) {
            return threadSafeProxy != null;
        }

        public virtual void Delete(object threadSafeProxy) {
			if(!source.IsLoadedProxy(threadSafeProxy))
				return;
            if(MessageBoxService.ShowMessage(string.Format(CommonResources.Confirmation_Delete, typeof(TEntity).Name), CommonResources.Confirmation_Caption, MessageButton.YesNo) != MessageResult.Yes)
                return;
            try {
                TPrimaryKey primaryKey = GetProxyPrimaryKey(threadSafeProxy);
                TEntity entity = helperRepository.Find(primaryKey);
                if(entity != null) {
					OnBeforeEntityDeleted(primaryKey, entity);
                    helperRepository.Remove(entity);
                    helperRepository.UnitOfWork.SaveChanges();
                    OnEntityDeleted(primaryKey, entity);
                }
            } catch (DbException e) {
                Refresh();
                MessageBoxService.ShowMessage(e.ErrorMessage, e.ErrorCaption, MessageButton.OK, MessageIcon.Error);
            }
            Refresh();
        }

        public bool CanDelete(object threadSafeProxy) {
            return threadSafeProxy != null;
        }

		protected ILayoutSerializationService LayoutSerializationService { get { return this.GetService<ILayoutSerializationService>(); } }

        string ViewName { get { return typeof(TEntity).Name + "InstantFeedbackCollectionView"; } }

        [Display(AutoGenerateField = false)]
        public virtual void OnLoaded() {
            string state = null;
            if(LayoutSerializationService != null && ViewModelLogicalLayoutHelper.PersistentViewsLayout.TryGetValue(ViewName, out state)) {
                LayoutSerializationService.Deserialize(state);
            }
        }

        [Display(AutoGenerateField = false)]
        public virtual void OnUnloaded() {
            SaveLayout();
        }

        void SaveLayout() {
            if(LayoutSerializationService != null) {
                ViewModelLogicalLayoutHelper.PersistentViewsLayout[ViewName] = LayoutSerializationService.Serialize();
            }
        }

        public virtual void Refresh() {
            Entities.Refresh();
        }

        protected TPrimaryKey GetProxyPrimaryKey(object threadSafeProxy) {
            var expression = RepositoryExtensions.GetProjectionPrimaryKeyExpression<TEntity, TProjection, TPrimaryKey>(helperRepository);
			return GetProxyPropertyValue(threadSafeProxy, expression);
        }

		protected TProperty GetProxyPropertyValue<TProperty>(object threadSafeProxy, Expression<Func<TProjection, TProperty>> propertyExpression) {
            return source.GetPropertyValue(threadSafeProxy, propertyExpression);
        }

        protected virtual void OnEntityDeleted(TPrimaryKey primaryKey, TEntity entity) {
            Messenger.Default.Send(new EntityMessage<TEntity, TPrimaryKey>(primaryKey, EntityMessageType.Deleted));
        }

        protected IMessageBoxService MessageBoxService { get { return this.GetRequiredService<IMessageBoxService>(); } }
        protected IDocumentManagerService DocumentManagerService { get { return this.GetService<IDocumentManagerService>(); } }

		protected virtual void OnBeforeEntityDeleted(TPrimaryKey primaryKey, TEntity entity) { }

        protected void DestroyDocument(IDocument document) {
            if(document != null)
                document.Close();
        }

        protected IRepository<TEntity, TPrimaryKey> CreateRepository() {
            return getRepositoryFunc(CreateUnitOfWork());
        }

        protected TUnitOfWork CreateUnitOfWork() {
            return unitOfWorkFactory.CreateUnitOfWork();
        }

        protected virtual void OnInitializeInRuntime() {
            Messenger.Default.Register<EntityMessage<TEntity, TPrimaryKey>>(this, x => OnMessage(x));
        }

        protected virtual void OnDestroy() {
            Messenger.Default.Unregister(this);
        }

        void OnMessage(EntityMessage<TEntity, TPrimaryKey> message) {
            Refresh();
        }

        protected IDocumentOwner DocumentOwner { get; private set; }

        #region IDocumentContent
        object IDocumentContent.Title { get { return null; } }

        void IDocumentContent.OnClose(CancelEventArgs e) {
			SaveLayout();
		}

        void IDocumentContent.OnDestroy() {
            OnDestroy();
        }

        IDocumentOwner IDocumentContent.DocumentOwner {
            get { return DocumentOwner; }
            set { DocumentOwner = value; }
        }
        #endregion

		#region ISupportLogicalLayout
        bool ISupportLogicalLayout.CanSerialize {
            get { return true; }
        }

		IDocumentManagerService ISupportLogicalLayout.DocumentManagerService {
            get { return DocumentManagerService; }
        }

		IEnumerable<object> ISupportLogicalLayout.LookupViewModels {
            get { return null; }
        }
        #endregion
	}
}