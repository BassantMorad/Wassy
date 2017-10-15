using Wassy.DAL.Models;

namespace Wassy.BLL.Functions
{
    public class AddNewLogin
    {
        Context db = new Context();
        public void Add(int id)
        {
            LogIn log = new LogIn();
           // log.Date = DateTimeOffset.Now.ToUnixTimeSeconds();
            log.UserId = id;
            db.LogIns.Add(log);
            db.SaveChanges();
        }
    }
}
