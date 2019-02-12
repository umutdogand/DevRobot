namespace ViewCreator.Exception
{
    using System;

    public class ViewCreatorException : Exception
    {
        private readonly string _errorCode;

        public string ErrorCode => _errorCode;

        public ViewCreatorException(string errorCode, string message) : base(message)
        {
            this._errorCode = errorCode;

        }
    }
}