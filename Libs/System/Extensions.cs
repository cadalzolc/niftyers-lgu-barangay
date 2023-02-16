namespace Niftyers;

public static class Extensions
    {

        #region  " To Null String "

        public static string ToNullString(this object obj, string Default = "")
        {
            if (obj == null) return Default;

            return obj.ToString() ?? Default;
        }

        #endregion

        #region " To Int "

        public static int ToInt(this object Obj, int Default = 0)
        {
            try
            {
                if (Obj == null) return Default;
                return Convert.ToInt32(Obj);
            }
            catch
            {
                return Default;
            }
        }

        #endregion

        #region " To Long "

        public static long ToLong(this object Obj, long Default = 0)
        {
            try
            {
                if (Obj == null) return Default;
                return Convert.ToInt64(Obj);
            }
            catch
            {
                return Default;
            }
        }

        #endregion

        #region " To Decimal "

        public static decimal ToDecimal(this object Obj, decimal Default = 0.00m)
        {
            try
            {
                if (Obj == null) return Default;
                return Convert.ToDecimal(Obj);
            }
            catch
            {
                return Default;
            }
        }

        #endregion

        #region " To Double "

        public static double ToDouble(this object Obj, double Default = 0.00)
        {
            try
            {
                if (Obj == null) return Default;
                return Convert.ToDouble(Obj);
            }
            catch
            {
                return Default;
            }
        }

        #endregion

        #region " To Date "

        public static DateTime ToDate(this object Obj)
        {
            try
            {
                if (Obj == null) return DateTime.UtcNow;
                if (Obj.ToString() == "") return DateTime.UtcNow;
                return Convert.ToDateTime(Obj);
            }
            catch
            {
                return DateTime.UtcNow;
            }
        }

        public static DateTime ToDate(this object Obj, TimeZoneInfo TzServer, TimeZoneInfo TzLocal)
        {
            try
            {
                if (Obj == null) return DateTime.UtcNow;

                var Tym = Convert.ToDateTime(Obj);
                var TymLocal = new DateTime(Tym.Year, Tym.Month, Tym.Day, Tym.Hour, Tym.Minute, Tym.Second);
                var NewTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(TymLocal, TzLocal.Id, TzServer.Id);

                return NewTime;
            }
            catch
            {
                return DateTime.UtcNow;
            }
        }

        #endregion

        #region " To Boolean "

        public static bool ToBoolean(this object Obj, bool Default = false)
        {
            try
            {
                if (Obj == null) return Default;
                return Convert.ToBoolean(Obj);
            }
            catch
            {
                return Default;
            }
        }

        public static bool ToBoolean(this int Obj, bool Default = false)
        {
            try
            {
                return (Obj == 1);
            }
            catch
            {
                return Default;
            }
        }

        #endregion

    }