using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_App.BL
{
    public class Data
    {
        public string movie_name;
        public float movie_price;
        public string release_date;
        public Data(string name,float movie_Price,string release_Date)
        {
            this.movie_name = name;
            this.movie_price = movie_Price;
            this.release_date = release_Date;

        }
    }
}
