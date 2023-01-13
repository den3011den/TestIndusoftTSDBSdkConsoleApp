using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.Serialization;

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Enums
{
    /// <summary>
    /// Перечисление значений определяющих качество значения
    /// </summary>
    [DataContract]
    [Description("Перечисление типов значений тэглв")]
    public enum PointDataType
    {
        /// <summary> плохое </summary>
        [EnumMember]
        [Description("булево")]
        Bool = 1,

        /// <summary> целое </summary>
        [EnumMember]
        [Description("Целое")]
        Integer = 2,

        /// <summary> дробное </summary>
        [EnumMember]
        [Description("дробное")]
        Float = 3,

        /// <summary> строка </summary>
        [EnumMember]
        [Description("строка")]
        String = 4

    }
}
