chrome.runtime.onStartup.addListener(function () {
  console.log('Browser startet. Updating files...');


  //Update files with c#


});


//List that contains the last url of all used tabs
//Can use array, because the tab id is an int which can be used in array as key
var tabsInfo = {};

chrome.webNavigation.onCompleted.addListener(async function (data) {
  var tab = await chrome.tabs.get(data.tabId);
  tabsInfo[data.tabId] = tab.url;
  console.log(tabsInfo);
});


chrome.webNavigation.onBeforeNavigate.addListener(function (data) {
  if (typeof data) {
    console.log("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
    console.log("onbeforeNavigate triggered successfull");
    console.log("want to open url: " + data.url);
    if(UrlMatch(data.url, "*test.de*")){
      console.log("match witch test.de successfull");
      console.log("Open last page: " + (tabsInfo[data.tabId] || "about:blank"));
      chrome.tabs.update(data.tabId, { url: tabsInfo[data.tabId] || "about:blank" }, function (tab) {
      });
    }
    else {
      console.log("no match witch test.de");
    }
  }
  else {
    console.log("onbeforeNavigate triggered failed");
  }
});


function UrlMatch(url, rule) {
  //add ^ and $ to the rule string to make sure the whole string has to match
  //(/?) means the submitted url can end on a / also if the rule does not
  //replace * with [^ ]* which is an asterix for zero or more non space characters
                 
  var regexPattern = ("^" + rule + "(/?)$").replace("*", "[^ ]*");
  return url.match(regexPattern);
}


