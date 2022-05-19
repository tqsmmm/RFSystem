namespace RFSystem.Maintain.MaintainReport
{
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.ReportSource;
    using CrystalDecisions.Shared;
    using System;
    using System.ComponentModel;
    using System.Drawing;

    [ToolboxBitmap(typeof(ExportOptions), "report.bmp")]
    public class Cached保养单 : Component, ICachedReport
    {
        public virtual ReportDocument CreateReport()
        {
            保养单 保养单 = new 保养单();
            保养单.Site = this.Site;
            return 保养单;
        }

        public virtual string GetCustomizedCacheKey(RequestContext request)
        {
            return null;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual TimeSpan CacheTimeOut
        {
            get
            {
                return CachedReportConstants.DEFAULT_TIMEOUT;
            }
            set
            {
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool IsCacheable
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public virtual bool ShareDBLogonInfo
        {
            get
            {
                return false;
            }
            set
            {
            }
        }
    }
}
