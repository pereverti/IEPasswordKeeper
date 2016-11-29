using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordKeeper
{
    internal class CustomFieldController
    {
        /// <summary>
        /// Add a custom field for a password
        /// </summary>
        /// <param name="fieldType">Type of the custom field</param>
        /// <param name="pwdId">Password id</param>
        /// <param name="webControlId">Id of the HTML control</param>
        internal void AddOrUpdateCustomField(Tools.TypeField fieldType, int pwdId, string webControlId)
        {
            using (PasswordKeeperEntities context = new PasswordKeeperEntities())
            {
                CustomField cField = (from field in context.CustomFields
                                      where field.IdPassword == pwdId && field.IdCustomFieldType == (int)fieldType
                                      select field).FirstOrDefault();

                if (cField == null)
                {
                    cField = new CustomField()
                    {
                        IdCustomFieldType = Convert.ToInt32(fieldType),
                        IdPassword = pwdId,
                        ControlId = webControlId
                    };

                    context.CustomFields.Add(cField);
                }
                else
                {
                    cField.ControlId = webControlId;
                }

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Get the list of customs fields for a given password entry
        /// </summary>
        /// <param name="pwdId">Id of the password entry</param>
        /// <returns>List of the custom fields of the password</returns>
        internal List<CustomFieldModel> GetCustomFields(int pwdId)
        {
            List<CustomFieldModel> customFields = new List<CustomFieldModel>();

            using (PasswordKeeperEntities context = new PasswordKeeperEntities())
            {
                IEnumerable<CustomField> cFields = from field in context.CustomFields
                                                   where field.IdPassword == pwdId
                                                   select field;

                foreach (CustomField field in cFields)
                {
                    customFields.Add(new CustomFieldModel()
                    {
                        PasswordId = field.IdPassword,
                        Type = (Tools.TypeField)field.IdCustomFieldType,
                        WebControlId = field.ControlId
                    });
                }
            }

            return customFields;
        }
    }
}
