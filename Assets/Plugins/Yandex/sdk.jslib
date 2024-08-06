mergeInto(LibraryManager.library, {
  ShowStartAdv: function() {
    ysdk.adv.showFullscreenAdv({
    callbacks: {
        onClose: function(wasShown) {
          SendMessage(myGameInstance, "StartTimer");
        },
        onError: function(error) {
          
        }
    }
    })
  },
});