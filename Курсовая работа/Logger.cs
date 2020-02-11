using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Курсовая_работа
{
      class Logger
    {
        protected  SaveManager output;

        public Logger(SaveManager log)
    {
        this.output = log;
    }

    public void WriteLine(string message)
    {
        output.WriteLine(message);
    }

    public void Close()
    {
        output.Close();
    }
}

    class LoadLogger
    {
        LoadManager loadManager;
        SaveManager log;

        public LoadLogger(LoadManager loadManager, SaveManager log)
        {
            this.loadManager = loadManager;
            this.log = log;
            loadManager.DidStartLoad += LoadStarted;
            loadManager.DidEndLoad += LoadFinished;
            loadManager.ObjectDidLoad += ObjectLoaded;
        }
        

        private void ObjectLoaded(string e)
        {
            log.WriteLine($"{DateTime.Now.ToString()} Объект файла {e} успешно считан. ");
        }

        private void LoadStarted(string e)
        {
            log.WriteLine($"{DateTime.Now.ToString()} Начало загрузки объектов файла : {e}");
        }

        private void LoadFinished(string e)
        {
            log.WriteLine($"{DateTime.Now.ToString()} Загрузка объекта {e} завершена.");
        }
}
}