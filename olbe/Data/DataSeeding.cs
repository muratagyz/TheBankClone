using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using olbe.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace olbe.Data
{
    public class DataSeeding
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<ArbankContext>();
            context.Database.Migrate();
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Users.Count() == 0)
                {
                    context.Users.AddRange(
                        new List<User> {
                            new User{userNameSurname="Ali Çalık",userMail="ali@gmail.com",userPassword="a",userTC="38123512154",userTel="+90 (544) 674 4887"},
                            new User{userNameSurname="Kemal Koca",userMail="kemalkoca@gmail.com",userPassword="b",userTC="a",userTel="+90 (532) 675 6867"},
                            new User{userNameSurname="Mert Balaban",userMail="balaban@gmail.com",userPassword="b",userTC="a",userTel="+90 (505) 981 5413"}
                        }
                    );
                }
                context.SaveChanges();
                if (context.Admin.Count() == 0)
                {
                    context.Admin.AddRange(
                        new List<Admin> {
                            new Admin {adminName="admin",adminPassword="admin" }
                        }
                    );
                }
                context.SaveChanges();
                if (context.ProcessType.Count() == 0)
                {
                    context.ProcessType.AddRange(
                        new List<ProcessType> {
                            new ProcessType {processType="Havale/EFT"},
                            new ProcessType{processType="Kredi Çekme"},
                            new ProcessType{processType="Para Yatırma"},
                            new ProcessType{processType="Para Çekme"}
                        }
                    );
                }
                context.SaveChanges();
                if (context.BankAccount.Count() == 0)
                {
                    context.BankAccount.AddRange(
                        new List<BankAccount> {
                            new BankAccount {Money=500,userId=1,IBAN="TR41554564561"},
                            new BankAccount {Money=750,userId=2,IBAN="TR12365453561"},
                            new BankAccount {Money=550,userId=3,IBAN="TR15454561412"}
                        }
                    );
                }
                context.SaveChanges();
                if (context.Process.Count() == 0)
                {
                    context.Process.AddRange(
                        new List<Process> {
                            new Process {processTypeId=1,processAmount=500,bankAccountId=1},
                            new Process {processTypeId=2,processAmount=700,bankAccountId=2},
                            new Process {processTypeId=2,processAmount=600,bankAccountId=3},
                        }
                    );
                }
                context.SaveChanges();

            }
        }
    }
}
