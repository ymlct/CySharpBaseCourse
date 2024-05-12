namespace L12Task2
{
    
    public delegate void TimerTick(long millis);
        
    public class Timer
    {
        
        public event TimerTick TimerTick;

        private long _currentValue;
        
        private int _step;
        
        private bool _isEnabled;
        

        public Timer(long currentValue, int step)
        {
            _currentValue = currentValue;
            _step = step;
        }


        public void Start()
        {
            _isEnabled = true;
        }
        
        public void Stop()
        {
            _isEnabled = false;
        }
        
        public void Reset()
        {
            _currentValue = 0L;
        }

        private void OnTick()
        {
            if (_isEnabled)
            {
                _currentValue += _step;
                TimerTick?.Invoke(_currentValue);
            }
        }

    }
}