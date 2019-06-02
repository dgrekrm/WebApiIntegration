using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinApp.Helper;
using XamarinApp.Models;

namespace XamarinApp.Managers {
    public class BookManager {

        public (bool, string, List<Book>) GetBooks() {
            try {
                var result = WebApiUtility.Get("api/Book/GetBooks").Result;
                return (true, "", JsonConvert.DeserializeObject<List<Book>>(result));
            } catch(Exception ex) {
                return (false, ex.Message, new List<Book>());
            }
        }
    }
}
