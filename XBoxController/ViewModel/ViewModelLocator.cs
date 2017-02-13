namespace XBoxController.ViewModel
{
    public class ViewModelLocator
    {
        private static MainViewModel _Main;

        public static MainViewModel Main => MainStatic;

        public ViewModelLocator()
        {
            CreateMain();
        }

        public static MainViewModel MainStatic
        {
            get
            {
                if (_Main == null)
                {
                    CreateMain();
                }
                return _Main;
            }
        }

        public static void CreateMain()
        {
            _Main = _Main ?? new MainViewModel();
        }

        public static void ClearMain()
        {
            _Main = null;
        }
    }
}
