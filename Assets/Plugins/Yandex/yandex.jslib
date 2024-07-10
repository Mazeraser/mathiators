mergeInto(LibraryManager.library,{

    SaveData: function(data){
        player.setData({
            score: data,
        },false)
    },
    LoadData: function(){
        player.getData().then(_data => {
            myGameInstance.SendMessage("MenuService","SetScore",_data); 
        });
    },
});