namespace RedBook
{
    internal static class ContextProvider
    {
		private static RedBookContext _redBookContext;

		public static RedBookContext RedBookContext
		{
			get
			{
                if (_redBookContext == null)
					_redBookContext = new RedBookContext();
				return _redBookContext;
			}
		}

	}
}
