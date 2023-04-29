﻿
namespace ShipsForm.SupportEntities.PatternObserver.Observers
{
    public interface IEventObserver<Event> : IEventObservableBase where Event : class
    {
        public void Update(Event ev);
    }
}
