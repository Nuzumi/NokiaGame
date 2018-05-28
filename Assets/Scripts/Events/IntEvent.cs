using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Events
{
    [CreateAssetMenu(fileName ="IntEvent",menuName ="events/IntEvent")]
    class IntEvent : NativeEvent<int>{}
}
