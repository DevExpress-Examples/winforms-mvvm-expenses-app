using System.Collections.Generic;
using DevExpress.Mvvm.POCO;
using MVVMExpenses.Models;

namespace MVVMExpenses.ViewModels
{
    //
    // TODO - your implementation
    static class CredentialsSource {
        static System.Collections.Hashtable credentials;
        static CredentialsSource() {
            credentials = new System.Collections.Hashtable();
            credentials.Add("Guest", GetHash(null));
            credentials.Add("John", GetHash("qwerty"));
            credentials.Add("Administrator", GetHash("admin"));
            credentials.Add("Mary", GetHash("12345"));
        }
        internal static bool Check(string login, string pwd) {
            return object.Equals(credentials[login], GetHash(pwd));
        }
        static object GetHash(string password) {
            return password;
        }
        internal static System.Collections.Generic.IEnumerable<string> GetUserNames() {
            foreach(string item in credentials.Keys)
                yield return item;
        }
    }
}
