namespace TTAG.Domain
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Validator
    {
        public List<string> ErrorMessages { get; set; } = new List<string>();

        public bool HasError { get; set; }

        public void CheckNotNullOrEmpty(string value, string errorMessage = "")
        {
            if (string.IsNullOrEmpty(value))
            {
                this.HasError = true;
                this.ErrorMessages.Add(string.IsNullOrEmpty(errorMessage) ? "Value is empty" : errorMessage);
            }
        }

        public void CheckEmail(string value, string errorMessage = "")
        {
            string pattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

            if (!Regex.IsMatch(value, pattern))
            {
                this.HasError = true;
                this.ErrorMessages.Add(string.IsNullOrEmpty(errorMessage) ? "Email is not valud" : errorMessage);
            }
        }

        public string GetMessage()
        {
            return string.Join(", ", this.ErrorMessages);
        }
    }
}
