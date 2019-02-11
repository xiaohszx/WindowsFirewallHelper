﻿using System;
using WindowsFirewallHelper.COMInterop;
using WindowsFirewallHelper.Helpers;

namespace WindowsFirewallHelper.FirewallAPIv2.Rules
{
    /// <inheritdoc cref="StandardRule" />
    /// <summary>
    ///     Contains properties of a Windows Firewall with Advanced Security rule in Windows 7 and above
    /// </summary>
    public class StandardRuleWin7 : StandardRule, IEquatable<StandardRuleWin7>
    {

        /// <inheritdoc />
        /// <summary>
        ///     Creates a new application rule for Windows Firewall with Advanced Security
        /// </summary>
        /// <param name="name">Name of the rule</param>
        /// <param name="filename">Address of the executable file</param>
        /// <param name="action">Action that this rule defines</param>
        /// <param name="direction">Data direction in which this rule applies to</param>
        /// <param name="profiles">The profile that this rule belongs to</param>
        // ReSharper disable once TooManyDependencies
        public StandardRuleWin7(
            string name,
            string filename,
            FirewallAction action,
            FirewallDirection direction,
            FirewallProfiles profiles) : base(name, filename, action, direction, profiles)
        {
        }

        /// <summary>
        ///     Creates a new general rule for Windows Firewall with Advanced Security
        /// </summary>
        /// <param name="name">Name of the rule</param>
        /// <param name="action">Action that this rule defines</param>
        /// <param name="direction">Data direction in which this rule applies to</param>
        /// <param name="profiles">The profile that this rule belongs to</param>
        // ReSharper disable once TooManyDependencies
        protected StandardRuleWin7(string name, FirewallAction action, FirewallDirection direction, FirewallProfiles profiles) :
            base(name, action, direction, profiles)
        {
        }

        /// <inheritdoc />
        /// <summary>
        ///     Creates a new port rule for Windows Firewall with Advanced Security
        /// </summary>
        /// <param name="name">Name of the rule</param>
        /// <param name="port">Port number of the rule</param>
        /// <param name="action">Action that this rule defines</param>
        /// <param name="direction">Data direction in which this rule applies to</param>
        /// <param name="profiles">The profile that this rule belongs to</param>
        // ReSharper disable once TooManyDependencies
        public StandardRuleWin7(
            string name,
            ushort port,
            FirewallAction action,
            FirewallDirection direction,
            FirewallProfiles profiles) : base(name, port, action, direction, profiles)
        {
        }
        
        /// <inheritdoc />
        // ReSharper disable once SuggestBaseTypeForParameter
        internal StandardRuleWin7(INetFwRule2 rule) : base(rule)
        {
        }

        /// <summary>
        ///     Gets or sets the behavior of this rule about the Edge Traversal
        /// </summary>
        public EdgeTraversalAction EdgeTraversalOptions
        {
            get
            {
                if (!Enum.IsDefined(typeof(EdgeTraversalAction), UnderlyingObject.EdgeTraversalOptions))
                {
                    throw new ArgumentOutOfRangeException();
                }

                return (EdgeTraversalAction)UnderlyingObject.EdgeTraversalOptions;
            }
            set
            {
                if (!Enum.IsDefined(typeof(EdgeTraversalAction), value))
                {
                    throw new ArgumentOutOfRangeException();
                }

                UnderlyingObject.EdgeTraversalOptions = (int) value;
            }
        }

        /// <summary>
        ///     Returns a Boolean value indicating if these class is available in the current machine
        /// </summary>
        public new static bool IsSupported
        {
            get => StandardRule.IsSupported && COMHelper.IsSupported<INetFwRule2>();
        }

        protected new INetFwRule2 UnderlyingObject
        {
            get => base.UnderlyingObject as INetFwRule2;
        }

        /// <inheritdoc />
        public bool Equals(StandardRuleWin7 other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (!base.Equals(other))
            {
                return false;
            }

            return UnderlyingObject.EdgeTraversalOptions == other.UnderlyingObject.EdgeTraversalOptions;
        }

        public static bool operator ==(StandardRuleWin7 left, StandardRuleWin7 right)
        {
            return Equals(left, right) || left?.Equals(right) == true;
        }

        public static bool operator !=(StandardRuleWin7 left, StandardRuleWin7 right)
        {
            return !(left == right);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return Equals(obj as StandardRuleWin7);
        }

        public new INetFwRule2 GetCOMObject()
        {
            return UnderlyingObject;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = base.GetHashCode();
                hashCode = hashCode * 467 + UnderlyingObject.EdgeTraversalOptions;

                return hashCode;
            }
        }
    }
}