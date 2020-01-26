using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Курсовая_работа
{
    interface ISaveManager
    {
        void WriteLine(string line);
        void WriteObject(IWritableObject obj);
    }

    interface IWritableObject
    {
        void Write(ISaveManager man);
    }
    class SaveManager : ISaveManager
    {
        StreamWriter file;

        public SaveManager(string filename)
        {
            file = new StreamWriter((filename), true);
        }

        public void WriteLine(string line)
        {
            file.WriteLine(line);

        }
        public void Close()
        {
            file.Close();
        }

        public void WriteObject(IWritableObject obj)
        {
            obj.Write(this);
        }
    }
}