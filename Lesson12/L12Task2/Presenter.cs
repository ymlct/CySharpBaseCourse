namespace L12Task2
{
    public class Presenter
    {

        private Timer _timer;
        
        private MainWindow _mainWindow;


        public Presenter(Timer timer, MainWindow mainWindow)
        {
            _timer = timer;
            _mainWindow = mainWindow;

            Init();
        }

        private void Init()
        {
            
        }
    }
}