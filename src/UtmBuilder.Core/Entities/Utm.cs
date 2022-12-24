using UtmBuilder.Core.Extensions;
using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Entities
{
    public class Utm
    {
        private const string KeyUtmSource = "utm_source";
        private const string KeyUtmMedium = "utm_medium";
        private const string KeyUtmCampaign = "utm_campaign";
        private const string KeyUtmId = "utm_id";
        private const string KeyUtmTerm = "utm_term";
        private const string KeyUtmContent = "utm_content";

        public Url Url { get; private set; }
        public Campaign Campaign { get; private set; }

        public Utm(Url url, Campaign campaign)
        {
            Url = url;
            Campaign = campaign;
        }

        public static implicit operator string(Utm utm) => utm.ToString();

        public static implicit operator Utm(string link)
        {
            var url = new Url(link);

            const char SeparatorQueryParams = '?';
            var segments = url.Address.Split(SeparatorQueryParams);

            const int MinimunLengthAllowed = 2;
            if (segments.Length < MinimunLengthAllowed)
                throw new InvalidUrlException("No segments were provided");
            const int PositionUrlAddress = 0;
            const int PositionQueryParams = 1;
            
            var pars = segments[PositionQueryParams].Split('&');

            const int PositionParameterKey = 0;
            const int PositionParameterValue = 1;
            var dictionary = pars.Select(parameter => parameter.Split('=')).ToDictionary(split => split[PositionParameterKey], split => split[PositionParameterValue]);

            dictionary.TryGetValue(KeyUtmSource, out var source);
            dictionary.TryGetValue(KeyUtmMedium, out var medium);
            dictionary.TryGetValue(KeyUtmCampaign, out var name);
            dictionary.TryGetValue(KeyUtmId, out var id);
            dictionary.TryGetValue(KeyUtmTerm, out var term);
            dictionary.TryGetValue(KeyUtmContent, out var content);

            url = new Url(segments[PositionUrlAddress]);
            var campaign = new Campaign(name!, source!, medium!, id, term, content);

            return new Utm(url, campaign);
        }

        public override string ToString()
        {
            var segments = new List<string>();
            segments.AddIfNotNull(KeyUtmSource, Campaign.Source);
            segments.AddIfNotNull(KeyUtmMedium, Campaign.Medium);
            segments.AddIfNotNull(KeyUtmCampaign, Campaign.Name);
            segments.AddIfNotNull(KeyUtmId, Campaign.Id);
            segments.AddIfNotNull(KeyUtmTerm, Campaign.Term);
            segments.AddIfNotNull(KeyUtmContent, Campaign.Content);

            return $"{Url.Address}?{string.Join("&", segments)}";
        }
    }
}