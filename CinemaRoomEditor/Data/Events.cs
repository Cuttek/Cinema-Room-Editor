using Microsoft.JSInterop;
using System.Runtime.CompilerServices;

namespace CinemaRoomEditor.Data
{
    public class Events
    {
        [JSInvokable]
        public static void JSMouseUp()
        {
            OnJsMouseUp(new object(),new EventArgs());
        }
        
        public delegate void OnJSMouseUpHandler(object sender, EventArgs e);
        public static event OnJSMouseUpHandler OnJsMouseUp = delegate { };

    }
}
