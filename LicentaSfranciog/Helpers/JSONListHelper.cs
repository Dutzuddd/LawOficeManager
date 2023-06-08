namespace LicentaSfranciog.Helpers
{
    public static class JSONListHelper
    {
        public static string GetEventListJSONString(List<Models.Eveniment> events)
        {
            var eventlist = new List<Eveniment>();
            var id = 1;
            foreach (var model in events)
            {
                var myevent = new Eveniment()
                {
                    id = model.Id,
                    start = model.StartTime,
                    end = model.EndTime,
                    resourceId = model.Location.Id,
                    description = model.Descriere,
                    title = model.Nume
                };
                eventlist.Add(myevent);
            }
            return System.Text.Json.JsonSerializer.Serialize(eventlist);
        }
        public static string GetResourceListJSONSString(List<Models.Loc> locations)
        {
            var resourcelist = new List<Resource>();
            foreach (var loc in locations)
            {
                var resource = new Resource()
                {
                    id = loc.Id,
                    title = loc.Name,
                    address = loc.Adresa
                };
                resourcelist.Add(resource);
            }
            return System.Text.Json.JsonSerializer.Serialize(resourcelist);
        }
    }
    public class Eveniment
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public int resourceId { get; set; }
        public string description { get; set; }
    }

    public class Resource
    {
        public int id { get; set; }
        public string title { get; set; }
        public string address { get; set; }
    }

}
