mergeInto(LibraryManager.library, {
  KongregateInitAPI: function (objectname, funcname) {
    if(typeof(kongregateUnitySupport) != 'undefined'){ 
			  	kongregateUnitySupport.initAPI(Pointer_stringify(objectname), Pointer_stringify(funcname));
    };
  },
  KongregateSubmitScore: function (name, value) {
    kongregate.stats.submit(Pointer_stringify(name), value);
  },
});