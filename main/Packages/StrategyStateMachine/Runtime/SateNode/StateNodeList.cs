using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace StateMachine
{
    public interface IStateNodeList : IDisposable
    {
        IReadOnlyCollection<IStateNode> Nodes { get; }

        IStateNode FirstState { get; }

        IStateNode Find(System.Predicate<IStateNode> match);

        void Add(IStateNode newNode);
    }

    public class StateNodeList : IStateNodeList
    {
        private List<IStateNode> nodes = new List<IStateNode>();
        public IReadOnlyCollection<IStateNode> Nodes { get => nodes; }

        private IStateNode firstState;
        public IStateNode FirstState { get => firstState; }

        public StateNodeList(List<IStateNode> nodes, IStateNode firstState)
        {
            this.nodes = nodes;
            this.firstState = firstState;
        }

        public IStateNode Find(System.Predicate<IStateNode> match)
        {
            return nodes.Find(match);
        }

        public void Add(IStateNode newNode)
        {
            nodes.Add(newNode);
        }

        public void Dispose()
        {
            foreach (IStateNode node in nodes)
                node.Dispose();
        }
    }
}