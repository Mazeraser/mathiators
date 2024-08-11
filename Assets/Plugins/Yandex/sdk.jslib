mergeInto(LibraryManager.library, {
  ShowStartAdv: function() {
    ysdk.adv.showFullscreenAdv({
    callbacks: {
        onClose: function(wasShown) {
          console.log('Ad was shown');
          myGameInstance.SendMessage('Timer(Clone)', 'StartTimer');
        },
        onError: function(error) {
          
        }
    }
    })
  },
});