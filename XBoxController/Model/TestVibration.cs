namespace XBoxController.Model
{
    using GalaSoft.MvvmLight;
    using Windows.Gaming.Input;

    public class TestVibration : ViewModelBase
    {
        //
        // 摘要:
        //     左振动马达的级别。 有效值介于 0.0 和 1.0 之间，其中 0.0 表示未使用马达，1.0 表示最大振动。
        private double _LeftMotor;
        //
        // 摘要:
        //     右振动马达的级别。 有效值介于 0.0 和 1.0 之间，其中 0.0 表示未使用马达，1.0 表示最大振动。
        private double _RightMotor;
        //
        // 摘要:
        //     左触发器振动级别。 有效值介于 0.0 和 1.0 之间，其中 0.0 表示未使用马达，1.0 表示最大振动。
        private double _LeftTrigger;
        //
        // 摘要:
        //     右触发器振动级别，有效值介于 0.0 和 1.0 之间，其中 0.0 表示未使用马达，1.0 表示最大振动。
        private double _RightTrigger;
        
        public double LeftMotor
        {
            get { return _LeftMotor; }
            set
            {
                _LeftMotor = value < 0 ? 0 : (value > 1 ? 1 : value);
            }
        }

        public double RightMotor
        {
            get { return _RightMotor; }
            set
            {
                _RightMotor = value;
                RaisePropertyChanged(() => RightMotor);
            }
        }

        public double LeftTrigger
        {
            get { return _LeftTrigger; }
            set
            {
                _LeftTrigger = value;
                RaisePropertyChanged(() => LeftTrigger);
            }
        }

        public double RightTrigger
        {
            get { return _RightTrigger; }
            set
            {
                _RightTrigger = value;
                RaisePropertyChanged(() => RightTrigger);
            }
        }

        public TestVibration() { }

        public TestVibration(GamepadVibration p)
        {
            this.LeftMotor = p.LeftMotor;
            this.RightMotor = p.RightMotor;
            this.LeftTrigger = p.LeftTrigger;
            this.RightTrigger = p.RightTrigger;
        }

        public GamepadVibration ToGamepadVibration()
        {
            GamepadVibration vibration = new GamepadVibration()
            {
                LeftMotor = this.LeftMotor,
                RightMotor = this.RightMotor,
                LeftTrigger = this.LeftTrigger,
                RightTrigger = this.RightTrigger
            };
            return vibration;
        }
    }
}
