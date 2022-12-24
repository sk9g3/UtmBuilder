using UtmBuilder.Core.ValueObjects.Abstracts;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.ValueObjects
{
    public class Url : ValueObject
    {
        public string Address { get; }
        public Url(string address)
        {
            InvalidUrlException.ThrowIfInvalid(address);
            Address = address;
        }
    }
}