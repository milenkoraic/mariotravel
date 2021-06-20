# Webpack MVC Configuration

Preconfigured Webpack module bundler for MVC applications 

### Development Build
npm install
- Installation of all required dependencies

npm run mvc-dev
* Builds all HTML, SCSS and JS unminified files to **/dist** folder
* Build all assets files from public folder to **/dist** folder

**DESTINATIONS**

* **/dist**/CSS/File Name/FileName.css
* **/dist**/JS /File Name/FileName.js
* **/dist**/Assets/images/File.ext
* **/dist**/Assets/icons/file.ext

**Public/Include/** files are used for imports from  **Public/lib** and **Public/vendor** paths

### Production build
npm run mvc-build
* Builds all HTML, SCSS and JS minified files to **\dist** folder 

**DESTINATIONS**

* **/dist**/CSS/File Name/FileName.**min**.css
* **/dist**/JS /File Name/FileName.**min**.js
* **/dist**/Assets/images/File.ext
* **/dist**/Assets/icons/file.ext


Destinations can be changed in the **webpack.common-mvc.js** file

If you don't want to use minified and unminified file versions in different
environments please uncomment CleanWebpackPlugin entries.

**NOTE: Webpack Dev Server is not configured in this project,
I am using it only for ASP.NET Core development** 



