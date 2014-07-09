Pratice
=======
下載專案程式碼後，請依以下步驟設定：

一、下載測試資料庫檔案AdventureWorks：
  https://www.dropbox.com/sh/dmtvl1nbon8ij9v/AABRMGCrk97gNIxGK0yz-vVta
  ＃下載完成後，請將檔案壓縮縮。
  
  
二、掛載測試資料庫AdventureWorks：
  1.叫出SQL Server物件總管，進行『新增查詢』。
  2.在查詢視窗中執行以下指令：
      
      --請將檔案路徑替換成您自己的解壓縮路徑。
      
      USE master;
      GO
      CREATE DATABASE AdventureWorks 
          ON (FILENAME = 'C:\Source\AdventureWorks2012_Data.mdf'),
          (FILENAME = 'C:\Source\AdventureWorks2012_Log.ldf')
          FOR ATTACH;
      GO
      

三、修改專案Web.Config：
  1.在方案總管中，找出專案BootStrap並編輯其Web.config的連線字串『ADB』，成為符合您資料庫的設定狀況，
    或直接在『SQL Server物件總管』-->資料庫-->Adventureworks-->右鍵『屬性』-->複製『連接字串』內容去取代。
