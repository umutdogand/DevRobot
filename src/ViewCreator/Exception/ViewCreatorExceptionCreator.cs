namespace ViewCreator.Exception
{
    public static class ViewCreatorExceptionCreator
    {
        #region Properties

        #endregion

        public static ViewCreatorException Create(string errorCode, string message)
        {
            return new ViewCreatorException(errorCode, message);
        }
    }
}