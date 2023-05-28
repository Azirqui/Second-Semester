using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_App.BL
{
    internal class Data_User
    {
        public string user_movie_name;
        public float user_movie_price;
        public string user_movie_date;

        public Data_User(string name, float movie_Price, string release_Date)
        {
            this.user_movie_name = name;
            this.user_movie_price = movie_Price;
            this.user_movie_date = release_Date;

        }
    }
}
