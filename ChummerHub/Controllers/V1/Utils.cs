using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChummerHub.Models.V1;

namespace ChummerHub.Controllers.V1
{
    public class Utils
    {
        public static ResultBase DbUpdateConcurrencyExceptionHandler(Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entry, ILogger logger)
        {
            var proposedValues = entry.CurrentValues;
            var databaseValues = entry.GetDatabaseValues();
            string msg = "";
            ResultBase res;
            try
            {
                
                foreach (var property in proposedValues.Properties)
                {
                    Object proposedValue = null;
                    Object databaseValue = null;
                    if (proposedValues?.Properties?.Contains(property) == true)
                        proposedValue = proposedValues[property];
                    if (databaseValues?.Properties?.Contains(property) == true)
                        databaseValue = databaseValues[property];

                    msg += Environment.NewLine + "property: " + property + Environment.NewLine;
                    msg += "\tproposedValue: " + proposedValue + Environment.NewLine;
                    msg += "\tdatabaseValue: " + databaseValue + Environment.NewLine;
                    logger.LogError(msg);
                    // TODO: decide which value should be written to database
                    // proposedValues[property] = <value to be saved>;
                }
                entry.OriginalValues.SetValues(databaseValues);
                var e = new NotSupportedException(
                    "(Codepoint 3) Don't know how to handle concurrency conflicts for "
                    + entry.Metadata.Name + ": " + msg);
                throw e;

            }
            catch (Exception exception)
            {
                var e = new NotSupportedException(
                    "(Codepoint 2) Don't know how to handle concurrency conflicts for "
                    + entry.Metadata.Name + ": " + msg, exception);
                throw e;
            }
        }
    }
}
