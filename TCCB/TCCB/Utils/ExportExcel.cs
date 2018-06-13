using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TCCB.Models.DAO;

namespace TCCB.Utils
{
    public class ExportExcel
    {
        public static Task GenerateXLSRegistrationCompleted(List<RegistrationInterview> registrationInterviews, string filePath)
        {
            return Task.Run(() =>
            {
                using (ExcelPackage pck = new ExcelPackage())
                {
                    //Create the worksheet 
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add(DateTime.Now.Date.ToString());
                    ws.Cells[2, 1].Value = "DANH SÁCH ỨNG VIÊN HOÀN THÀNH HỒ SƠ";
                    ws.Cells["A2:I2"].Merge = true;

                    ws.Cells[3, 1].Value = registrationInterviews.ElementAt(0).ManagementUnit.FullName;
                    ws.Cells["A3:I3"].Merge = true;
                    ws.Cells[4, 1].Value = "Tính tới ngày " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                    ws.Cells["A4:I4"].Merge = true;
                    ws.Cells[6, 1].Value = "STT";
                    ws.Cells[6, 2].Value = "HỌ VÀ TÊN LÓT";
                    ws.Cells[6, 3].Value = "TÊN";                   
                    ws.Cells[6, 4].Value = "NGÀY SINH";
                    ws.Cells[6, 5].Value = "GIỚI TÍNH";
                    ws.Cells[6, 6].Value = "SỐ CMND";
                    ws.Cells[6, 7].Value = "NƠI Ở HIỆN NAY";
                    ws.Cells[6, 8].Value = "HÔ KHẨU THƯỞNG TRÚ";
                    ws.Cells[6, 9].Value = "SỐ ĐIỆN THOẠI";
                    ws.Cells[6, 10].Value = "EMAIL";
                    ws.Cells[6, 11].Value = "TRƯỜNG ĐÀO TẠO";
                    ws.Cells[6, 12].Value = "TRƯỜNG NÀY Ở";
                    ws.Cells[6, 13].Value = "TỐT NGHIỆP";
                    ws.Cells[6, 14].Value = "HỆ ĐÀO TẠO";
                    ws.Cells[6, 15].Value = "NĂM TỐT NGHIỆP";
                    ws.Cells[6, 16].Value = "KIỂU ĐÀO TẠO";
                    ws.Cells[6, 17].Value = "ĐIỂM TB";
                    ws.Cells[6, 18].Value = "ĐIỂM ĐỒ ÁN";
                    ws.Cells[6, 19].Value = "CHỨNG CHỈ NVSP";
                    ws.Cells[6, 20].Value = "MÔN ĐĂNG KÍ";
                    ws.Cells[6, 21].Value = "BẬC";
                    ws.Cells[6, 22].Value = "TIN HỌC";
                    ws.Cells[6, 23].Value = "NGOẠI NGỮ";
                    ws.Cells[6, 24].Value = "LÀM VIỆC TRONG NGÀNH";
                    ws.Cells[6, 25].Value = "NĂM VÀO NGÀNH";
                    ws.Cells[6, 26].Value = "MÃ NGẠCH";
                    ws.Cells[6, 27].Value = "HỆ SỐ LƯƠNG";
                    ws.Cells[6, 28].Value = "MỐC NÂNG LƯƠNG LẦN SAU";                    
                
                    for (int i = 0; i < registrationInterviews.Count(); i++)
                    {
                        ws.Cells[i + 7, 1].Value = i + 1;
                        ws.Cells[i + 7, 2].Value = registrationInterviews.ElementAt(i).CandidateLastName;
                        ws.Cells[i + 7, 3].Value = registrationInterviews.ElementAt(i).CandidateFirstName;
                        ws.Cells[i + 7, 4].Value = registrationInterviews.ElementAt(i).DOB.Value.Day + "/" + registrationInterviews.ElementAt(i).DOB.Value.Month + "/" + registrationInterviews.ElementAt(i).DOB.Value.Year;
                        ws.Cells[i + 7, 5].Value = registrationInterviews.ElementAt(i).IsMale == true ? "Nam" : "Nữ";
                        ws.Cells[i + 7, 6].Value = registrationInterviews.ElementAt(i).IdentifyCard;
                        ws.Cells[i + 7, 7].Value = registrationInterviews.ElementAt(i).CurrentLivingAddress.HouseNumber + "," + registrationInterviews.ElementAt(i).CurrentLivingAddress.Ward.Type + " " + registrationInterviews.ElementAt(i).CurrentLivingAddress.Ward.Name + ", " + registrationInterviews.ElementAt(i).CurrentLivingAddress.Ward.District.Type + " " + registrationInterviews.ElementAt(i).CurrentLivingAddress.Ward.District.Name;
                        ws.Cells[i + 7, 8].Value = registrationInterviews.ElementAt(i).HouseHold.HouseNumber + "," + registrationInterviews.ElementAt(i).HouseHold.Ward.Type + " " + registrationInterviews.ElementAt(i).HouseHold.Ward.Name + ", " + registrationInterviews.ElementAt(i).HouseHold.Ward.District.Type + " " + registrationInterviews.ElementAt(i).HouseHold.Ward.District.Name + ", " + registrationInterviews.ElementAt(i).HouseHold.Ward.District.Province.Type + " " + registrationInterviews.ElementAt(i).HouseHold.Ward.District.Province.Name;
                        ws.Cells[i + 7, 9].Value = registrationInterviews.ElementAt(i).PhoneNumber;
                        ws.Cells[i + 7, 10].Value = registrationInterviews.ElementAt(i).Email;
                        ws.Cells[i + 7, 11].Value = registrationInterviews.ElementAt(i).UniversityName;
                        ws.Cells[i + 7, 12].Value = registrationInterviews.ElementAt(i).Province.Type + " " + registrationInterviews.ElementAt(i).Province.Name;
                        ws.Cells[i + 7, 13].Value = registrationInterviews.ElementAt(i).GraduationClassfication.Name;
                        ws.Cells[i + 7, 14].Value = registrationInterviews.ElementAt(i).TrainningCategory.Name;
                        ws.Cells[i + 7, 15].Value = registrationInterviews.ElementAt(i).GraduatedAtYear;
                        ws.Cells[i + 7, 16].Value = registrationInterviews.ElementAt(i).IsNienChe == true? "Niên chế" : "Tín chỉ";
                        ws.Cells[i + 7, 17].Value = registrationInterviews.ElementAt(i).GPA;
                        ws.Cells[i + 7, 18].Value = registrationInterviews.ElementAt(i).CaptionProjectPoint;
                        ws.Cells[i + 7, 19].Value = registrationInterviews.ElementAt(i).IsHadNghiepVuSupham == true? "Đã có" : "Chưa có";
                        ws.Cells[i + 7, 20].Value = registrationInterviews.ElementAt(i).Subject.PositionInterview.Name + " " + registrationInterviews.ElementAt(i).Subject.Name;
                        ws.Cells[i + 7, 21].Value = registrationInterviews.ElementAt(i).SchoolDegree.Notation;
                        ws.Cells[i + 7, 22].Value = registrationInterviews.ElementAt(i).InfomationTechnologyDegree.Name;
                        ws.Cells[i + 7, 23].Value = registrationInterviews.ElementAt(i).ForeignLanguageCertification.Name;
                        ws.Cells[i + 7, 24].Value = registrationInterviews.ElementAt(i).StatusWorikingInEducation.Name;
                        ws.Cells[i + 7, 25].Value = registrationInterviews.ElementAt(i).NamVaoNghanh;
                        ws.Cells[i + 7, 26].Value = registrationInterviews.ElementAt(i).MaNgach;
                        ws.Cells[i + 7, 27].Value = registrationInterviews.ElementAt(i).HeSoLuong;
                        ws.Cells[i + 7, 28].Value = registrationInterviews.ElementAt(i).MocNangLuongLansau;                        

                    }
                    using (ExcelRange rng = ws.Cells["A2:I2"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 18;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Red);
                    }
                    using (ExcelRange rng = ws.Cells["A3:I3"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 14;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Red);
                    }
                    using (ExcelRange rng = ws.Cells["A4:I4"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 14;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Red);
                    }
                    using (ExcelRange rng = ws.Cells["A6:AB6"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;        //Set Pattern for the background to Solid 
                        rng.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);  //Set color to blue 
                        rng.Style.Font.Color.SetColor(Color.Black);
                        rng.AutoFitColumns();
                    }
                   
                    
                    pck.SaveAs(new FileInfo(filePath));
                }
            });
        }
        public static Task GenerateXLSRegistrationInprocess(List<RegistrationInterview> registrationInterviews, string filePath)
        {
            return Task.Run(() =>
            {
                using (ExcelPackage pck = new ExcelPackage())
                {
                    //Create the worksheet 
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add(DateTime.Now.Date.ToString());
                    ws.Cells[2, 1].Value = "DANH SÁCH ỨNG VIÊN CHƯA HOÀN THÀNH HỒ SƠ";
                    ws.Cells["A2:I2"].Merge = true;
                    ws.Cells[3, 1].Value = registrationInterviews.ElementAt(0).ManagementUnit.FullName;
                    ws.Cells["A3:I3"].Merge = true;
                    ws.Cells[4, 1].Value = "Tính tới ngày " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                    ws.Cells["A4:I4"].Merge = true;
                    ws.Cells[6, 1].Value = "STT";
                    ws.Cells[6, 2].Value = "HỌ VÀ TÊN LÓT";
                    ws.Cells[6, 3].Value = "TÊN";               
                    for (int i = 0; i < registrationInterviews.Count(); i++)
                    {
                        ws.Cells[i + 7, 1].Value = i + 1;
                        ws.Cells[i + 7, 2].Value = registrationInterviews.ElementAt(i).CandidateLastName;
                        ws.Cells[i + 7, 3].Value = registrationInterviews.ElementAt(i).CandidateFirstName;                        

                    }
                    using (ExcelRange rng = ws.Cells["A2:I2"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 18;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Red);
                    }
                    using (ExcelRange rng = ws.Cells["A3:I3"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 14;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Red);
                    }
                    using (ExcelRange rng = ws.Cells["A4:I4"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 14;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Red);
                    }
                    using (ExcelRange rng = ws.Cells["A6:C6"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;        //Set Pattern for the background to Solid 
                        rng.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);  //Set color to blue 
                        rng.Style.Font.Color.SetColor(Color.Black);
                        rng.AutoFitColumns();
                    }


                    pck.SaveAs(new FileInfo(filePath));
                }
            });
        }
        public static Task GenerateXLSRegistrationRegisted(List<RegistrationInterview> registrationInterviews, string filePath)
        {
            return Task.Run(() =>
            {
                using (ExcelPackage pck = new ExcelPackage())
                {
                    //Create the worksheet 
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add(DateTime.Now.Date.ToString());
                    ws.Cells[2, 1].Value = "DANH SÁCH ỨNG VIÊN ĐÃ ĐĂNG KÍ HỒ SƠ";
                    ws.Cells["A2:I2"].Merge = true;
                    ws.Cells[3, 1].Value = registrationInterviews.ElementAt(0).ManagementUnit.FullName;
                    ws.Cells["A3:I3"].Merge = true;
                    ws.Cells[4, 1].Value = "Tính tới ngày " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                    ws.Cells["A4:I4"].Merge = true;
                    ws.Cells[6, 1].Value = "STT";
                    ws.Cells[6, 2].Value = "HỌ VÀ TÊN LÓT";
                    ws.Cells[6, 3].Value = "TÊN";
                    for (int i = 0; i < registrationInterviews.Count(); i++)
                    {
                        ws.Cells[i + 7, 1].Value = i + 1;
                        ws.Cells[i + 7, 2].Value = registrationInterviews.ElementAt(i).CandidateLastName;
                        ws.Cells[i + 7, 3].Value = registrationInterviews.ElementAt(i).CandidateFirstName;

                    }
                    using (ExcelRange rng = ws.Cells["A2:I2"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 18;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Red);
                    }
                    using (ExcelRange rng = ws.Cells["A3:I3"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 14;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Red);
                    }
                    using (ExcelRange rng = ws.Cells["A4:I4"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 14;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Red);
                    }
                    using (ExcelRange rng = ws.Cells["A6:C6"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;        //Set Pattern for the background to Solid 
                        rng.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);  //Set color to blue 
                        rng.Style.Font.Color.SetColor(Color.Black);
                        rng.AutoFitColumns();
                    }


                    pck.SaveAs(new FileInfo(filePath));
                }
            });
        }
        public static Task GenerateXLSRegistrationIsValid(List<RegistrationInterview> registrationInterviews, string filePath)
        {
            return Task.Run(() =>
            {
                using (ExcelPackage pck = new ExcelPackage())
                {
                    //Create the worksheet 
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add(DateTime.Now.Date.ToString());
                    ws.Cells[2, 1].Value = "DANH SÁCH ỨNG VIÊN CÓ HỒ SƠ HỢP LỆ SAU KHI ĐÃ RÀ XOÁT";
                    ws.Cells["A2:I2"].Merge = true;

                    ws.Cells[3, 1].Value = registrationInterviews.ElementAt(0).ManagementUnit.FullName;
                    ws.Cells["A3:I3"].Merge = true;
                    ws.Cells[4, 1].Value = "Tính tới ngày " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                    ws.Cells["A4:I4"].Merge = true;
                    ws.Cells[6, 1].Value = "STT";
                    ws.Cells[6, 2].Value = "HỌ VÀ TÊN LÓT";
                    ws.Cells[6, 3].Value = "TÊN";
                    ws.Cells[6, 4].Value = "NGÀY SINH";
                    ws.Cells[6, 5].Value = "GIỚI TÍNH";
                    ws.Cells[6, 6].Value = "SỐ CMND";
                    ws.Cells[6, 7].Value = "NƠI Ở HIỆN NAY";
                    ws.Cells[6, 8].Value = "HÔ KHẨU THƯỞNG TRÚ";
                    ws.Cells[6, 9].Value = "SỐ ĐIỆN THOẠI";
                    ws.Cells[6, 10].Value = "EMAIL";
                    ws.Cells[6, 11].Value = "TRƯỜNG ĐÀO TẠO";
                    ws.Cells[6, 12].Value = "TRƯỜNG NÀY Ở";
                    ws.Cells[6, 13].Value = "TỐT NGHIỆP";
                    ws.Cells[6, 14].Value = "HỆ ĐÀO TẠO";
                    ws.Cells[6, 15].Value = "NĂM TỐT NGHIỆP";
                    ws.Cells[6, 16].Value = "KIỂU ĐÀO TẠO";
                    ws.Cells[6, 17].Value = "ĐIỂM TB";
                    ws.Cells[6, 18].Value = "ĐIỂM ĐỒ ÁN";
                    ws.Cells[6, 19].Value = "CHỨNG CHỈ NVSP";
                    ws.Cells[6, 20].Value = "MÔN ĐĂNG KÍ";
                    ws.Cells[6, 21].Value = "BẬC";
                    ws.Cells[6, 22].Value = "TIN HỌC";
                    ws.Cells[6, 23].Value = "NGOẠI NGỮ";
                    ws.Cells[6, 24].Value = "LÀM VIỆC TRONG NGÀNH";
                    ws.Cells[6, 25].Value = "NĂM VÀO NGÀNH";
                    ws.Cells[6, 26].Value = "MÃ NGẠCH";
                    ws.Cells[6, 27].Value = "HỆ SỐ LƯƠNG";
                    ws.Cells[6, 28].Value = "MỐC NÂNG LƯƠNG LẦN SAU";
                    ws.Cells[6, 29].Value = "NGƯỜI RA XOÁT";
                    for (int i = 0; i < registrationInterviews.Count(); i++)
                    {
                        ws.Cells[i + 7, 1].Value = i + 1;
                        ws.Cells[i + 7, 2].Value = registrationInterviews.ElementAt(i).CandidateLastName;
                        ws.Cells[i + 7, 3].Value = registrationInterviews.ElementAt(i).CandidateFirstName;
                        ws.Cells[i + 7, 4].Value = registrationInterviews.ElementAt(i).DOB.Value.Day + "/" + registrationInterviews.ElementAt(i).DOB.Value.Month + "/" + registrationInterviews.ElementAt(i).DOB.Value.Year;
                        ws.Cells[i + 7, 5].Value = registrationInterviews.ElementAt(i).IsMale == true ? "Nam" : "Nữ";
                        ws.Cells[i + 7, 6].Value = registrationInterviews.ElementAt(i).IdentifyCard;
                        ws.Cells[i + 7, 7].Value = registrationInterviews.ElementAt(i).CurrentLivingAddress.HouseNumber + "," + registrationInterviews.ElementAt(i).CurrentLivingAddress.Ward.Type + " " + registrationInterviews.ElementAt(i).CurrentLivingAddress.Ward.Name + ", " + registrationInterviews.ElementAt(i).CurrentLivingAddress.Ward.District.Type + " " + registrationInterviews.ElementAt(i).CurrentLivingAddress.Ward.District.Name;
                        ws.Cells[i + 7, 8].Value = registrationInterviews.ElementAt(i).HouseHold.HouseNumber + "," + registrationInterviews.ElementAt(i).HouseHold.Ward.Type + " " + registrationInterviews.ElementAt(i).HouseHold.Ward.Name + ", " + registrationInterviews.ElementAt(i).HouseHold.Ward.District.Type + " " + registrationInterviews.ElementAt(i).HouseHold.Ward.District.Name + ", " + registrationInterviews.ElementAt(i).HouseHold.Ward.District.Province.Type + " " + registrationInterviews.ElementAt(i).HouseHold.Ward.District.Province.Name;
                        ws.Cells[i + 7, 9].Value = registrationInterviews.ElementAt(i).PhoneNumber;
                        ws.Cells[i + 7, 10].Value = registrationInterviews.ElementAt(i).Email;
                        ws.Cells[i + 7, 11].Value = registrationInterviews.ElementAt(i).UniversityName;
                        ws.Cells[i + 7, 12].Value = registrationInterviews.ElementAt(i).Province.Type + " " + registrationInterviews.ElementAt(i).Province.Name;
                        ws.Cells[i + 7, 13].Value = registrationInterviews.ElementAt(i).GraduationClassfication.Name;
                        ws.Cells[i + 7, 14].Value = registrationInterviews.ElementAt(i).TrainningCategory.Name;
                        ws.Cells[i + 7, 15].Value = registrationInterviews.ElementAt(i).GraduatedAtYear;
                        ws.Cells[i + 7, 16].Value = registrationInterviews.ElementAt(i).IsNienChe == true ? "Niên chế" : "Tín chỉ";
                        ws.Cells[i + 7, 17].Value = registrationInterviews.ElementAt(i).GPA;
                        ws.Cells[i + 7, 18].Value = registrationInterviews.ElementAt(i).CaptionProjectPoint;
                        ws.Cells[i + 7, 19].Value = registrationInterviews.ElementAt(i).IsHadNghiepVuSupham == true ? "Đã có" : "Chưa có";
                        ws.Cells[i + 7, 20].Value = registrationInterviews.ElementAt(i).Subject.PositionInterview.Name + " " + registrationInterviews.ElementAt(i).Subject.Name;
                        ws.Cells[i + 7, 21].Value = registrationInterviews.ElementAt(i).SchoolDegree.Notation;
                        ws.Cells[i + 7, 22].Value = registrationInterviews.ElementAt(i).InfomationTechnologyDegree.Name;
                        ws.Cells[i + 7, 23].Value = registrationInterviews.ElementAt(i).ForeignLanguageCertification.Name;
                        ws.Cells[i + 7, 24].Value = registrationInterviews.ElementAt(i).StatusWorikingInEducation.Name;
                        ws.Cells[i + 7, 25].Value = registrationInterviews.ElementAt(i).NamVaoNghanh;
                        ws.Cells[i + 7, 26].Value = registrationInterviews.ElementAt(i).MaNgach;
                        ws.Cells[i + 7, 27].Value = registrationInterviews.ElementAt(i).HeSoLuong;
                        ws.Cells[i + 7, 28].Value = registrationInterviews.ElementAt(i).MocNangLuongLansau;
                        ws.Cells[i + 7, 29].Value = registrationInterviews.ElementAt(i).Account1.LastName + " " + registrationInterviews.ElementAt(i).Account1.FirstName;

                    }
                    using (ExcelRange rng = ws.Cells["A2:I2"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 18;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Red);
                    }
                    using (ExcelRange rng = ws.Cells["A3:I3"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 14;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Red);
                    }
                    using (ExcelRange rng = ws.Cells["A4:I4"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Font.Size = 14;
                        rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        rng.Style.Font.Color.SetColor(Color.Red);
                    }
                    using (ExcelRange rng = ws.Cells["A6:AC6"])
                    {
                        rng.Style.Font.Bold = true;
                        rng.Style.Fill.PatternType = ExcelFillStyle.Solid;        //Set Pattern for the background to Solid 
                        rng.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);  //Set color to blue 
                        rng.Style.Font.Color.SetColor(Color.Black);
                        rng.AutoFitColumns();
                    }


                    pck.SaveAs(new FileInfo(filePath));
                }
            });
        }
    }
}