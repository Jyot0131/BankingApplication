using System;

namespace BankingApplication
{
    public class Customer
    {

        private String customer_id = Guid.NewGuid().ToString().Replace("-","");

        public String Customer_ID
        {
            get
            {
                return customer_id;
            }
        }

    }
}
