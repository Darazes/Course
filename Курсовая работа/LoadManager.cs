using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Курсовая_работа
{
    interface ILoadManager
    {
        string ReadLine();
        IReadbleObject Read(IReadableObjectLoader loader);
    }

    interface IReadbleObject
    { }

    interface IReadableObjectLoader
    {
        IReadbleObject Load(ILoadManager man);
    }

    delegate void Message(string e);

    class LoadManager : ILoadManager
    {
        StreamReader input;
        string filename;
        public Message DidStartLoad;
        public Message DidEndLoad;
        public Message ObjectDidLoad;

        public LoadManager(string filename)
        {
            this.filename = filename;
            input = null;
        }

        public IReadbleObject Read(IReadableObjectLoader loader)
        {
            return loader.Load(this);
        }

        public void OpenText()
        {
            if (input != null)
                throw new IOException("Load Error");
            DidStartLoad(filename);
            input = File.OpenText(filename);
            
        }
        public bool IsLoading
        {
            get { return input != null && !input.EndOfStream; }
        }
        public string ReadLine()
        {
            if (input == null)
                throw new IOException("Load Error");

            //string line = input.ReadLine();
            return input.ReadLine(); ;
        }

        public int Lenght(string filename)
        {
            return System.IO.File.ReadAllLines(filename).Length;
        }

        

        public string[] Read(LoadManager sr)
        {
            string str = sr.ReadLine();
            string[] elements = str.Split(';');
            ObjectDidLoad(filename);
            return elements;
        }

        public void EndRead(SaveManager log)
        {
            if (input == null)
                throw new IOException("Load Error");
            DidEndLoad(filename);
            input.Close();
            log.Close();
        }
    }
}