using Google.Apis.Util;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireStoreTut.Classes
{
    internal class FireStoreHelper
    {

        private static FireStoreHelper instance;
        private string filePath;
        public FirestoreDb firestoreDb;
        FireStoreHelper()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"config.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            firestoreDb = FirestoreDb.Create("todolist-4a455");
            Debug.WriteLine("OKE");
        }

        internal static FireStoreHelper Instance {
            get {
                if (instance == null)
                {
                    instance = new FireStoreHelper();
                }
                return instance;
            }
            private set => instance = value;
        }

        public void test()
        {
            MessageBox.Show("SUCCESS");
        }
        public async void addDocument2Collection(string collection, string doc = null)
        {
            if (doc == null)
            {
                CollectionReference collectionReference = firestoreDb.Collection(collection);
                Dictionary<string, object> newDoc = new Dictionary<string, object>()
                {
                    {"name", "Nga" },
                    {"age", 21 }
                };
                await collectionReference.AddAsync(newDoc);
                MessageBox.Show("ADDED DOC");
            }else
            {
                DocumentReference documentReference = firestoreDb.Collection(collection).Document(doc);
                Dictionary<string, object> field = new Dictionary<string, object>()
                {
                    {"name", "Hung" },
                    {"age", 21 }
                };
                var temp = await documentReference.GetSnapshotAsync();
                Debug.WriteLine(temp);
                MessageBox.Show("ADDED FIELD");   
            }
        }
        public async void getDataFromDocument(string collection, string doc = null)
        {
            DocumentReference documentReference = firestoreDb.Collection(collection).Document(doc);
            DocumentSnapshot snapshot = await documentReference.GetSnapshotAsync();
            if (snapshot.Exists)
            {
                MessageBox.Show("EXISTED");
            }else
            {
                MessageBox.Show("NOT EXISTED");
            }
        }
    }
}
