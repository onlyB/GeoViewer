namespace GeoViewer.Models
{
    public class Validation
    {
    }
    

/*
    public partial class Account : EntityObject
    {
        partial void OnEmailChanging(string value)
        {
            //if (!value.IsValidEmail()) throw new Exception("Email không đúng định dạng!");
        }

        partial void OnUsernameChanging(string value)
        {
            if (!value.IsValidUsername()) throw new Exception("Tên tài khoản không hợp lệ. Tài khoản hợp lệ chỉ gồm chữ cái, số dấu _ và có độ dài từ 4-20 ký tự!");
        }

        partial void OnFullNameChanging(string value)
        {
            if (!value.IsValidLength(0, 100)) throw new Exception("Tên người dùng không vượt quá 100 ký tự!");
        }

    }

    public partial class Sensor : EntityObject
    {
        partial void OnAlarmEnabledChanging(bool value)
        {
            //if ((this.MinValue == null && this.MaxValue == null) || (this.MinValue != null && this.MaxValue != null && this.MinValue >= this.MaxValue)) throw new Exception("Giá trị cảnh báo không hợp lệ!");
        }

        partial void OnMinValueChanging(decimal? value)
        {
            //if ((value != null && this.MaxValue != null && value >= this.MaxValue)) throw new Exception("Giá trị cảnh báo không hợp lệ!");
        }

        partial void OnMaxValueChanging(decimal? value)
        {
            //if ((value != null && this.MinValue != null && value <= this.MinValue)) throw new Exception("Giá trị cảnh báo không hợp lệ!");
        }

        partial void OnNameChanging(string value)
        {
            if (!value.IsValidLength(1, 200)) throw new Exception("Tên cảm biến không dài quá 250 ký tự!");
        }

        partial void OnDescriptionChanging(string value)
        {
            if (!value.IsValidLength(0, 500)) throw new Exception("Thông tin cảm biến không dài quá 500 ký tự!");
        }
    }

    public partial class Logger:EntityObject
    {
        partial void OnDelimiterChanging(string value)
        {
            if (string.IsNullOrEmpty(value)) value = ",";
        }

        partial void OnReadIntervalChanging(int value)
        {
            if (value <= 0) value = 1800;
        }

        partial void OnNameChanging(string value)
        {
            if (!value.IsValidLength(1, 200)) throw new Exception("Tên logger không dài quá 200 ký tự!");
        }
    }
*/
}
