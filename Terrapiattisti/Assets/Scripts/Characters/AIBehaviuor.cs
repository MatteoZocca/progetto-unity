using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviuor {

    public delegate void Function();
    private Stack<Function> states;

    public AIBehaviuor() {
        this.states = new Stack<Function>();
    }

    public void PushState(Function state) {
        if (state != GetCurrentState()) {
            states.Push(state);
        }
    }

    public Function PopState() {
        return states.Pop();
    }

    public Function GetCurrentState() {
        return (states.Count > 0) ? states.Peek() : null;
    }

    // Update is called once per frame
    public void Update() {
        GetCurrentState().Invoke();
    }
}
