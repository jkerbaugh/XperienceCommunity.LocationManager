using System;
using System.Data;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using CMS;
using CMS.DataEngine;
using CMS.DataEngine.Internal;
using CMS.Helpers;
using XperienceCommunity.LocationManager;
using XperienceCommunity.Locator.Converters;
using XperienceCommunity.Locator.DataTypes;
using XperienceCommunity.Locator.Models;

[assembly: RegisterObjectType(typeof(LocationInfo), LocationInfo.OBJECT_TYPE)]

namespace XperienceCommunity.LocationManager
{
    /// <summary>
    /// Data container class for <see cref="LocationInfo"/>.
    /// </summary>
    [Serializable]
    public partial class LocationInfo : AbstractInfo<LocationInfo, ILocationInfoProvider>, IInfoWithId, IInfoWithName
    {
        /// <summary>
        /// Object type.
        /// </summary>
        public const string OBJECT_TYPE = "locationmanager.location";


        /// <summary>
        /// Type information.
        /// </summary>
#warning "You will need to configure the type info."
        public static readonly ObjectTypeInfo TYPEINFO = new ObjectTypeInfo(typeof(LocationInfoProvider), OBJECT_TYPE, "LocationManager.Location", "LocationID", null, null, "Name", "Name", null, null, null)
        {
            TouchCacheDependencies = true,
            DependsOn = new List<ObjectDependency>()
            {
                new ObjectDependency("ChannelID", "cms.channel", ObjectDependencyEnum.Required),
            },
        };


        /// <summary>
        /// Location ID.
        /// </summary>
        [DatabaseField]
        public virtual int LocationID
        {
            get => ValidationHelper.GetInteger(GetValue(nameof(LocationID)), 0);
            set => SetValue(nameof(LocationID), value);
        }


        /// <summary>
        /// Name.
        /// </summary>
        [DatabaseField]
        public virtual string Name
        {
            get => ValidationHelper.GetString(GetValue(nameof(Name)), String.Empty);
            set => SetValue(nameof(Name), value);
        }


        /// <summary>
        /// Latitude.
        /// </summary>
        [DatabaseField]
        public virtual Geolocation Geolocation
        {
            get => LocatorJsonConverter.ConvertToSystemRepresentation(GetValue(nameof(Geolocation), new Geolocation()), new Geolocation(), CultureInfo.CurrentCulture);
            set => LocatorJsonConverter.ConvertToDbRepresentation(value, "", CultureInfo.CurrentCulture);
        }
        
        /// <summary>
        /// Latitude.
        /// </summary>
        [DatabaseField]
        public virtual BusinessHours BusinessHours
        {
            get => LocatorJsonConverter.ConvertToSystemRepresentation(GetValue(nameof(BusinessHours), new BusinessHours()), new BusinessHours(), CultureInfo.CurrentCulture);
            set => LocatorJsonConverter.ConvertToDbRepresentation(value, "", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Channel ID.
        /// </summary>
        [DatabaseField]
        public virtual int ChannelID
        {
            get => ValidationHelper.GetInteger(GetValue(nameof(ChannelID)), 0);
            set => SetValue(nameof(ChannelID), value);
        }


        /// <summary>
        /// Deletes the object using appropriate provider.
        /// </summary>
        protected override void DeleteObject()
        {
            Provider.Delete(this);
        }


        /// <summary>
        /// Updates the object using appropriate provider.
        /// </summary>
        protected override void SetObject()
        {
            Provider.Set(this);
        }


        /// <summary>
        /// Constructor for de-serialization.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Streaming context.</param>
        protected LocationInfo(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }


        /// <summary>
        /// Creates an empty instance of the <see cref="LocationInfo"/> class.
        /// </summary>
        public LocationInfo()
            : base(TYPEINFO)
        {
        }


        /// <summary>
        /// Creates a new instances of the <see cref="LocationInfo"/> class from the given <see cref="DataRow"/>.
        /// </summary>
        /// <param name="dr">DataRow with the object data.</param>
        public LocationInfo(DataRow dr)
            : base(TYPEINFO, dr)
        {
        }
    }
}