using System;
using System.Collections.Generic;

namespace SparkDotNet {

    /// <summary>
    /// A set of people in Webex Teams.
    /// Organizations may manage other organizations or be managed themselves.
    /// This organizations resource can be accessed only by an admin.
    /// </summary>
    public class Organization : WebexObject
    {
        #region Properties
        /// <summary>
        /// A unique identifier for the organization.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Full name of the organization.
        /// </summary>
        public string displayName { get; set; }

        /// <summary>
        /// The date and time the organization was created.
        /// </summary>
        public DateTime created { get; set; }

        #region XSI Properties, only available with XSI enabled Organizations and spark:xsi_read scope
        /// <summary>
        /// The base path to xsi-actions.
        /// </summary>
        public string XsiActionsEndpoint  { get; set; }

        /// <summary>
        /// The base path to xsi-events.
        /// </summary>
        public string XsiEventsEndpoint { get; set; }

        /// <summary>
        /// The base path to xsi-events-channel.
        /// </summary>
        public string XsiEventsChannelEndpoint { get; set; }

        /// <summary>
        /// "api-" prepended to the bcBaseDomain value for the organization.
        /// </summary>
        public string XsiDomain { get; set; }
        #endregion XSI Properties

        #endregion Properties

        #region AR Objects
        [SparkARResettable(DefaultValue = null)]
        private List<Person> _people = null;
        public List<Person> People { get
            {
                if (_people != null)
                    return _people;
                if (SparkClient == null)
                    return null;

                _people = SparkClient.GetPeopleAsync(orgId: id).Result;

                foreach (Person person in _people)
                    person.UpdateObject(this);

                return _people;
            }; }


        [SparkARResettable(DefaultValue = null)]
        private List<Location> _locations = null;
        public List<Location> Locations
        {
            get
            {
                if (_locations != null)
                    return _locations;
                if (SparkClient == null)
                    return null;

                _locations = SparkClient.GetLocationsAsync(orgId: id).Result;

                foreach (Location location in _locations)
                    location.UpdateObject(this);

                return _locations;
            };
        }

        [SparkARResettable(DefaultValue = null)]
        private List<Place> _places = null;
        public List<Place> Places
        {
            get
            {
                if (_places != null)
                    return _places;
                if (SparkClient == null)
                    return null;

                _places = SparkClient.GetPlacesAsync(orgId: id).Result;

                foreach (Place place in _places)
                    place.UpdateObject(this);

                return _places;
            };
        }

        #endregion AR Objects
    }
}