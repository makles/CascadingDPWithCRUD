using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Intrinsics.X86;

namespace CascadingDPWithCRUD.Models
{
    public class DatabaseScript
    {

//        USE[EmployeeDb]
//GO
///****** Object:  Table [dbo].[Department]    Script Date: 03/11/2022 09:51:31 ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE TABLE[dbo].[Department]
//        (

//    [DepartmentId][int] NOT NULL,

//    [DeptName] [nvarchar] (100) NULL
//) ON[PRIMARY]
//GO
///****** Object:  Table [dbo].[Desination]    Script Date: 03/11/2022 09:51:31 ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE TABLE[dbo].[Desination]
//        (

//    [DesignationId][int] NOT NULL,

//    [DesinationName] [nchar] (100) NULL,
//	[DepartmentId][int] NULL
//) ON[PRIMARY]
//GO
///****** Object:  Table [dbo].[Employee]    Script Date: 03/11/2022 09:51:31 ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE TABLE[dbo].[Employee]
//        (

//    [EmployeeId][int] NOT NULL,

//    [EmpName] [nvarchar] (100) NULL,
//	[DepartmentId][int] NULL,
//	[DesignationId][int] NULL,
//	[JoinDate][date] NULL,
//	[ContactNo][nchar] (15) NULL
//) ON[PRIMARY]
//GO
///****** Object:  StoredProcedure [dbo].[sp_Deparment_sel]    Script Date: 03/11/2022 09:51:31 ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO

//Create proc[dbo].[sp_Deparment_sel]
//as
//Begin


//SELECT[DepartmentId]
//      ,[DeptName]
//  FROM[dbo].[Department]
//        ENd
//GO
///****** Object:  StoredProcedure [dbo].[sp_DepartByDesination_Sel]    Script Date: 03/11/2022 09:51:31 ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//create proc[dbo].[sp_DepartByDesination_Sel]
//        @DepartmentId int
//as
//Begin

//SELECT[DesignationId]
//      ,[DesinationName]
//      ,[DepartmentId]
//  FROM[dbo].[Desination]
//        where DepartmentId = @DepartmentId
//ENd
//GO
///****** Object:  StoredProcedure [dbo].[sp_Desination_sel]    Script Date: 03/11/2022 09:51:31 ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//create proc[dbo].[sp_Desination_sel]
//as
//Begin

//SELECT[DesignationId]
//      ,[DesinationName]
//      ,[DepartmentId]
//  FROM[EmployeeDb].[dbo].[Desination]

//        End
//GO
///****** Object:  StoredProcedure [dbo].[SP_Employee_del]    Script Date: 03/11/2022 09:51:31 ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO

//create proc[dbo].[SP_Employee_del]
//        @EmployeeId int
//as
//Begin

// Delete from[dbo].[Employee]
//        where EmployeeId = @EmployeeId
// End
//GO
///****** Object:  StoredProcedure [dbo].[sp_employee_ins_up]    Script Date: 03/11/2022 09:51:31 ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO

//CREATE proc[dbo].[sp_employee_ins_up]
//        (
//           @EmployeeId int
//		   ,@EmpName nvarchar(100)
//           ,@DepartmentId int
//           ,@DesignationId int
//           ,@JoinDate date
//           , @ContactNo nchar(15)
//		   ,@ActionType int
//		   )
//as

//Begin
//if(@ActionType=1)
//Declare @vEmployeeId bigint
//set @vEmployeeId=(select ISNULL(MAX(EmployeeId),0) + 1 from[dbo].[Employee])

//Begin
//   INSERT INTO[dbo].[Employee]
//        (
//           EmployeeId
//           ,[EmpName]
//           ,[DepartmentId]
//           ,[DesignationId]
//           ,[JoinDate]
//           ,[ContactNo])
//     VALUES
//           (
//            @vEmployeeId

//           , @EmpName
//           , @DepartmentId
//           , @DesignationId
//           , @JoinDate
//           , @ContactNo

//           )
//End




//End



//GO
//        /****** Object:  StoredProcedure [dbo].[sp_Employee_sel]    Script Date: 03/11/2022 09:51:31 ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO

//CREATE proc[dbo].[sp_Employee_sel]
//as

//Begin
// Select   EmployeeId
//           ,[EmpName]
//           ,E.[DepartmentId]
//		   ,D.DeptName
//           ,E.[DesignationId],
//		    DE.DesinationName
//           ,[JoinDate]
//           ,[ContactNo] from[dbo].[Employee] as E
//           left join Department D on E.DepartmentId=D.DepartmentId
//           left join Desination DE on E.DesignationId=DE.DesignationId
// End
//GO
///****** Object:  StoredProcedure [dbo].[sp_employee_up]    Script Date: 03/11/2022 09:51:31 ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO
//CREATE proc[dbo].[sp_employee_up]
//        (
//           @EmployeeId int
//		   ,@EmpName nvarchar(100)
//           ,@DepartmentId int
//           ,@DesignationId int
//           ,@JoinDate date
//           , @ContactNo nchar(15)
//		   )
//as

//Begin

//UPDATE[dbo].[Employee]
//        SET[EmpName] = @EmpName
//      ,[DepartmentId] = @DepartmentId
//      ,[DesignationId] = @DesignationId
//      ,[JoinDate] = @JoinDate
//      ,[ContactNo] = @ContactNo
// WHERE EmployeeId=@EmployeeId

//End
//GO
///****** Object:  StoredProcedure [dbo].[SP_EmployeGetById_Sel]    Script Date: 03/11/2022 09:51:31 ******/
//SET ANSI_NULLS ON
//GO
//SET QUOTED_IDENTIFIER ON
//GO

//create proc[dbo].[SP_EmployeGetById_Sel]
//        @EmployeeId int
//as
// Begin
// Select   EmployeeId
//           ,[EmpName]
//           ,E.[DepartmentId]
//		   ,D.DeptName
//           ,E.[DesignationId],
//		    DE.DesinationName
//           ,[JoinDate]
//           ,[ContactNo] from[dbo].[Employee] as E
//           left join Department D on E.DepartmentId=D.DepartmentId
//           left join Desination DE on E.DesignationId=DE.DesignationId where EmployeeId=@EmployeeId
// End
//GO

   }
}
