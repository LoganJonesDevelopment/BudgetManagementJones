using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManagement.PL;


namespace BudgetManagement.BL
{
   public class User
    {
  
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }

        public string BillingAddress { get; set; }
        public string Address { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public int Insert()
        {
            int result = 0;
            try
            {
                using (BudgetManagementEntities dc = new BudgetManagementEntities())
                {
                    tblUser user = new tblUser();
               
                    user.Id = Guid.NewGuid();
                    user.FirstName = this.FirstName;
                    user.LastName = this.LastName;
                    user.BillingAddress = this.BillingAddress;
                    user.Address = this.Address;
                    user.City = this.City;
                    user.State = this.State;
                    user.ZipCode = this.ZipCode;
                    user.Password = this.Password;
                    user.Email = this.Email;


                    dc.tblUsers.Add(user);
                    result = dc.SaveChanges();
                    return result;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Delete()
        {
            try
            {
                using (BudgetManagementEntities dc = new BudgetManagementEntities())
                {
                    if (this.Id != Guid.Empty)
                    {
                        tblUser user = dc.tblUsers.Where(c => c.Id == this.Id).FirstOrDefault();
                        dc.tblUsers.Remove(user);
                        return dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Id is not set.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadById()
        {
            try
            {
                using (BudgetManagementEntities dc = new BudgetManagementEntities())
                {
                    if (this.Id != Guid.Empty)
                    {
                        tblUser user = dc.tblUsers.FirstOrDefault(c => c.Id == this.Id);

                        if (user != null)
                        {

                            this.Id = user.Id;
                            this.FirstName = user.FirstName;
                            this.LastName = user.LastName;
                            this.BillingAddress = this.BillingAddress;
                            this.Address = this.Address;
                            this.City = this.City;
                            this.State = this.State;
                            this.ZipCode = this.ZipCode;
                            this.Password = this.Password;
                            this.Email = this.Email;
                           
                        }
                        else
                        {
                            throw new Exception("Could not find the row.");
                        }
                    }
                    else
                    {
                        throw new Exception("Id is not set.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update()
        {
            try
            {
                using (BudgetManagementEntities dc = new BudgetManagementEntities())
                {
                    if (this.Id != Guid.Empty)
                    {
                        tblUser user = dc.tblUsers.Where(c => c.Id == this.Id).FirstOrDefault();
                        user.FirstName = this.FirstName;
                        user.LastName = this.LastName;
                        user.BillingAddress = this.BillingAddress;
                        user.Address = this.Address;
                        user.City = this.City;
                        user.State = this.State;
                        user.ZipCode = this.ZipCode;
                        user.Password = this.Password;
                        user.Email = this.Email;
                        return dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Id is not set.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class UserList : List<User>
    {
        public void Load()
        {
            try
            {
                using (BudgetManagementEntities dc = new BudgetManagementEntities())
                {
                    dc.tblUsers
                        .ToList()
                        .ForEach(c => this
                        .Add(new User
                        {
                            Id = c.Id,
                            FirstName = c.FirstName,
                            LastName = c.LastName,
                            Address = c.Address,
                            BillingAddress = c.BillingAddress,
                            City = c.City,
                            State = c.State,
                            ZipCode = c.ZipCode,
                            Password = c.Password,
                            Email = c.Email,



                        }));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
