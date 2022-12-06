## This repo illustrates an issue with MudBlazor's MudTable after publish.
https://github.com/MudBlazor/MudBlazor/issues/5911

### To recreate the issue using this repo
1. Clone the repo
2. Publish the app to Azure or other app service
3. Load the app and view the table

#### The app should show the table with the data, but instead shows an empty table when published

### App Before Publish
![Screenshot 2022-12-06 at 8 56 23 AM](https://user-images.githubusercontent.com/1041228/205948108-37c4d919-729a-4aeb-8c5c-22c38ebf0797.png)

### App After Publish
![Screenshot 2022-12-06 at 8 57 35 AM](https://user-images.githubusercontent.com/1041228/205948231-bc55b549-02f6-4496-8d28-2638c2012b29.png)
