

namespace AddinX.Configuration.Contract
{
    /// <summary>
    /// Specifies the type of a ConfigurationElementCollectionType object.
    /// </summary>
    public enum ConfigurationElementCollectionTypeEnum
    {
        /// <summary>
        /// The default type of ConfigurationElementCollection.
        /// Collections of this type contain elements that can be merged across a hierarchy of configuration files.
        /// At any particular level within such a hierarchy, add, remove, and clear directives are used to modify any inherited properties and specify new ones.
        /// </summary>
        AddRemoveClearMap,

        /// <summary>
        /// Same as AddRemoveClearMap, except that this type causes the ConfigurationElementCollection object to sort its contents such that inherited elements are listed last.
        /// </summary>
        AddRemoveClearMapAlternate,

        /// <summary>
        /// Collections of this type contain elements that apply to the level at which they are specified, and to all child levels. A child level cannot modify the properties specified by a parent element of this type.
        /// </summary>
        BasicMap,

        /// <summary>
        /// Same as BasicMap, except that this type causes the ConfigurationElementCollection object to sort its contents such that inherited elements are listed last.
        /// </summary>
        BasicMapAlternate
    }
}