using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
using System.Text;

namespace GeoViewer.Models
{
        public partial class GeoViewerEntities
        {
            public void AttachUpdatedObject(System.Data.Objects.DataClasses.IEntityWithKey obj, EntityState objState = EntityState.Modified)
            {
                ObjectStateEntry state;
                bool exist = this.ObjectStateManager.TryGetObjectStateEntry(obj, out state);
                if (!exist || state == null || state.State == EntityState.Detached)
                {
                    this.Attach(obj);
                    this.ObjectStateManager.ChangeObjectState(obj, objState);
                }
            }
        }

}
