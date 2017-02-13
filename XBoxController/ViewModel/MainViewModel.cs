namespace XBoxController.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Threading;
    using Windows.Gaming.Input;
    using Windows.UI.Xaml;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using GalaSoft.MvvmLight.Threading;

    public class MainViewModel : ViewModelBase
    {
        private Gamepad _GamePad;
        private GamepadReading _Reading;
        private GamepadVibration _Vibration;
        private bool _Wireless;

        private ulong _Timestamp;
        private double _LT;
        private double _RT;
        private double _LeftThumbstickX;
        private double _LeftThumbstickY;
        private double _RightThumbstickX;
        private double _RightThumbstickY;
        private bool _Menu;
        private bool _View;
        private bool _A;
        private bool _B;
        private bool _X;
        private bool _Y;
        private bool _DUp;
        private bool _DDown;
        private bool _DLeft;
        private bool _DRight;
        private bool _LS;
        private bool _RS;
        private bool _L;
        private bool _R;
        private bool _Paddle1;
        private bool _Paddle2;
        private bool _Paddle3;
        private bool _Paddle4;
        private double _LeftMotor;
        private double _RightMotor;
        private double _LeftTrigger;
        private double _RightTrigger;

        private CancellationTokenSource ReadCancelTokenSource;
        private DispatcherTimer Timer;
        private TimeSpan Period = TimeSpan.FromMilliseconds(10);

        public RelayCommand<bool> ConnectCommand { get; private set; }
        public ObservableCollection<Gamepad> GamePadCollection { get; private set; }
        public Gamepad GamePad
        {
            get { return _GamePad; }
            set
            {
                _GamePad = value;
                if (GamePad != null)
                {

                    Wireless = GamePad.IsWireless;
                }
                if (ConnectCommand != null)
                {
                    ConnectCommand.RaiseCanExecuteChanged();
                }
                RaisePropertyChanged(() => GamePad);
            }
        }
        public GamepadReading Reading
        {
            get { return _Reading; }
            private set
            {
                if (!value.Equals(Reading))
                {
                    _Reading = value;
                    Timestamp = Reading.Timestamp;
                    LT = Reading.LeftTrigger;
                    RT = Reading.RightTrigger;
                    LeftThumbstickX = Reading.LeftThumbstickX;
                    LeftThumbstickY = Reading.LeftThumbstickY;
                    RightThumbstickX = Reading.RightThumbstickX;
                    RightThumbstickY = Reading.RightThumbstickY;
                    Menu = Reading.Buttons.HasFlag(GamepadButtons.Menu);
                    View = Reading.Buttons.HasFlag(GamepadButtons.View);
                    A = Reading.Buttons.HasFlag(GamepadButtons.A);
                    B = Reading.Buttons.HasFlag(GamepadButtons.B);
                    X = Reading.Buttons.HasFlag(GamepadButtons.X);
                    Y = Reading.Buttons.HasFlag(GamepadButtons.Y);
                    DUp = Reading.Buttons.HasFlag(GamepadButtons.DPadUp);
                    DDown = Reading.Buttons.HasFlag(GamepadButtons.DPadDown);
                    DLeft = Reading.Buttons.HasFlag(GamepadButtons.DPadLeft);
                    DRight = Reading.Buttons.HasFlag(GamepadButtons.DPadRight);
                    LS = Reading.Buttons.HasFlag(GamepadButtons.LeftShoulder);
                    RS = Reading.Buttons.HasFlag(GamepadButtons.RightShoulder);
                    L = Reading.Buttons.HasFlag(GamepadButtons.LeftThumbstick);
                    R = Reading.Buttons.HasFlag(GamepadButtons.RightThumbstick);
                    Paddle1 = Reading.Buttons.HasFlag(GamepadButtons.Paddle1);
                    Paddle2 = Reading.Buttons.HasFlag(GamepadButtons.Paddle2);
                    Paddle3 = Reading.Buttons.HasFlag(GamepadButtons.Paddle3);
                    Paddle4 = Reading.Buttons.HasFlag(GamepadButtons.Paddle4);
                    // RaisePropertyChanged(() => Reading);
                }
            }
        }
        public GamepadVibration Vibration
        {
            get { return _Vibration; }
            private set
            {
                if (!value.Equals(Vibration))
                {
                    _Vibration = value;
                    LeftMotor = Vibration.LeftMotor;
                    RightMotor = Vibration.RightMotor;
                    LeftTrigger = Vibration.LeftTrigger;
                    RightTrigger = Vibration.RightTrigger;
                    // RaisePropertyChanged(() => Vibration);
                }
            }
        }
        public bool Wireless
        {
            get { return _Wireless; }
            private set
            {
                _Wireless = value;
                RaisePropertyChanged(() => Wireless);
            }
        }
        public ulong Timestamp
        {
            get { return _Timestamp; }
            private set
            {
                _Timestamp = value;
                RaisePropertyChanged(() => Timestamp);
            }
        }
        public double LT
        {
            get { return _LT; }
            private set
            {
                _LT = value;
                RaisePropertyChanged(() => LT);
            }
        }
        public double RT
        {
            get { return _RT; }
            private set
            {
                _RT = value;
                RaisePropertyChanged(() => RT);
            }
        }
        public double LeftThumbstickX
        {
            get { return _LeftThumbstickX; }
            private set
            {
                _LeftThumbstickX = value;
                RaisePropertyChanged(() => LeftThumbstickX);
            }
        }
        public double LeftThumbstickY
        {
            get { return _LeftThumbstickY; }
            private set
            {
                _LeftThumbstickY = value;
                RaisePropertyChanged(() => LeftThumbstickY);
            }
        }
        public double RightThumbstickX
        {
            get { return _RightThumbstickX; }
            private set
            {
                _RightThumbstickX = value;
                RaisePropertyChanged(() => RightThumbstickX);
            }
        }
        public double RightThumbstickY
        {
            get { return _RightThumbstickY; }
            private set
            {
                _RightThumbstickY = value;
                RaisePropertyChanged(() => RightThumbstickY);
            }
        }
        public bool Menu
        {
            get { return _Menu; }
            private set
            {
                _Menu = value;
                RaisePropertyChanged(() => Menu);
            }
        }
        public bool View
        {
            get { return _View; }
            private set
            {
                _View = value;
                RaisePropertyChanged(() => View);
            }
        }
        public bool A
        {
            get { return _A; }
            private set
            {
                _A = value;
                RaisePropertyChanged(() => A);
            }
        }
        public bool B
        {
            get { return _B; }
            private set
            {
                _B = value;
                RaisePropertyChanged(() => B);
            }
        }
        public bool X
        {
            get { return _X; }
            private set
            {
                _X = value;
                RaisePropertyChanged(() => X);
            }
        }
        public bool Y
        {
            get { return _Y; }
            private set
            {
                _Y = value;
                RaisePropertyChanged(() => Y);
            }
        }
        public bool DUp
        {
            get { return _DUp; }
            private set
            {
                _DUp = value;
                RaisePropertyChanged(() => DUp);
            }
        }
        public bool DDown
        {
            get { return _DDown; }
            private set
            {
                _DDown = value;
                RaisePropertyChanged(() => DDown);
            }
        }
        public bool DLeft
        {
            get { return _DLeft; }
            private set
            {
                _DLeft = value;
                RaisePropertyChanged(() => DLeft);
            }
        }
        public bool DRight
        {
            get { return _DRight; }
            private set
            {
                _DRight = value;
                RaisePropertyChanged(() => DRight);
            }
        }
        public bool LS
        {
            get { return _LS; }
            private set
            {
                _LS = value;
                RaisePropertyChanged(() => LS);
            }
        }
        public bool RS
        {
            get { return _RS; }
            private set
            {
                _RS = value;
                RaisePropertyChanged(() => RS);
            }
        }
        public bool L
        {
            get { return _L; }
            private set
            {
                _L = value;
                RaisePropertyChanged(() => L);
            }
        }
        public bool R
        {
            get { return _R; }
            private set
            {
                _R = value;
                RaisePropertyChanged(() => R);
            }
        }
        public bool Paddle1
        {
            get { return _Paddle1; }
            private set
            {
                _Paddle1 = value;
                RaisePropertyChanged(() => Paddle1);
            }
        }
        public bool Paddle2
        {
            get { return _Paddle2; }
            private set
            {
                _Paddle2 = value;
                RaisePropertyChanged(() => Paddle2);
            }
        }
        public bool Paddle3
        {
            get { return _Paddle3; }
            private set
            {
                _Paddle3 = value;
                RaisePropertyChanged(() => Paddle3);
            }
        }
        public bool Paddle4
        {
            get { return _Paddle4; }
            private set
            {
                _Paddle4 = value;
                RaisePropertyChanged(() => Paddle4);
            }
        }
        public double LeftMotor
        {
            get { return _LeftMotor; }
            set
            {
                if (LeftMotor != value)
                {
                    _LeftMotor = value;
                    SetGamepadVibration();
                    RaisePropertyChanged(() => LeftMotor);
                }
            }
        }
        public double RightMotor
        {
            get { return _RightMotor; }
            set
            {
                if (RightMotor != value)
                {
                    _RightMotor = value;
                    SetGamepadVibration();
                    RaisePropertyChanged(() => RightMotor);
                }
            }
        }
        public double LeftTrigger
        {
            get { return _LeftTrigger; }
            set
            {
                if (LeftTrigger != value)
                {
                    _LeftTrigger = value;
                    SetGamepadVibration();
                    RaisePropertyChanged(() => LeftTrigger);
                }
            }
        }
        public double RightTrigger
        {
            get { return _RightTrigger; }
            set
            {
                if (RightTrigger != value)
                {
                    _RightTrigger = value;
                    SetGamepadVibration();
                    RaisePropertyChanged(() => RightTrigger);
                }
            }
        }

        public MainViewModel()
        {
            Initialize();
            Gamepad.GamepadAdded += Gamepad_GamepadAdded;
            Gamepad.GamepadRemoved += Gamepad_GamepadRemoved;
        }

        private void Initialize()
        {
            GamePadCollection = new ObservableCollection<Gamepad>();
            foreach (Gamepad pad in Gamepad.Gamepads)
            {
                GamePadCollection.Add(pad);
            }
            GamePad = GamePadCollection.Count > 0 ? GamePadCollection[0] : null;
            ConnectCommand = new RelayCommand<bool>(ConnectGamepad, (p) => { return GamePad != null; });
            Timer = new DispatcherTimer() { Interval = Period };
            Timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, object e)
        {
            if (!ReadCancelTokenSource.Token.IsCancellationRequested)
            {
                Reading = GamePad.GetCurrentReading();
                Vibration = GamePad.Vibration;
            }
        }

        private void ConnectGamepad(bool parameter)
        {
            if (!parameter)
            {
                ReadCancelTokenSource = new CancellationTokenSource();
                Timer.Start();
            }
            else
            {
                if (ReadCancelTokenSource != null)
                {
                    Timer.Stop();
                    ReadCancelTokenSource.Cancel();
                }
            }
        }

        private void SetGamepadVibration()
        {
            GamePad.Vibration = new GamepadVibration()
            {
                LeftMotor = LeftMotor,
                RightMotor = RightMotor,
                LeftTrigger = LeftTrigger,
                RightTrigger = RightTrigger
            };
        }

        private void Gamepad_GamepadAdded(object sender, Gamepad e)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(() =>
            {
                if (GamePadCollection == null)
                {
                    GamePadCollection = new ObservableCollection<Gamepad>();
                }
                GamePadCollection.Add(e);
                GamePad = GamePad ?? e;
            });
        }

        private void Gamepad_GamepadRemoved(object sender, Gamepad e)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(() =>
            {
                if (e.Equals(GamePad))
                {
                    GamePad = null;
                }
                if (GamePadCollection.Contains(e))
                {
                    GamePadCollection.Remove(e);
                }
            });
        }
    }
}
