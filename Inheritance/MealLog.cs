using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class MealLog : IDisposable
    {
        // Flag: Has Dispose already been called? 
        bool disposed = false;

        StreamWriter writer;

        public MealLog()
        {
            FileStream stream = File.Create("meallog.txt");
            writer = new StreamWriter(stream);
        }

        ~MealLog()
        {
            Dispose(false);
        }

        public async Task Log(string details)
        {
            await writer.WriteLineAsync(details);
        }

        // Public implementation of Dispose pattern callable by consumers. 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern. 
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here. 
                //
                if (writer != null)
                    writer.Dispose();
            }

            // Free any unmanaged objects here. 
            //
            disposed = true;
        }
    }
}
