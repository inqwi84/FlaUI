﻿using FlaUI.Core;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.Patterns;
using FlaUI.Core.Patterns.Infrastructure;
using FlaUI.Core.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class ValuePattern : PatternBaseWithInformation<UIA.IUIAutomationValuePattern, ValuePatternInformation>, IValuePattern
    {
        public ValuePattern(AutomationObjectBase automationObject, UIA.IUIAutomationValuePattern nativePattern) : base(automationObject, nativePattern)
        {
            Properties = new ValuePatternProperties();
        }

        IValuePatternInformation IPatternWithInformation<IValuePatternInformation>.Cached
        {
            get { return Cached; }
        }

        IValuePatternInformation IPatternWithInformation<IValuePatternInformation>.Current
        {
            get { return Current; }
        }

        public IValuePatternProperties Properties { get; private set; }

        public void SetValue(string value)
        {
            ComCallWrapper.Call(() => NativePattern.SetValue(value));
        }

        protected override ValuePatternInformation CreateInformation(bool cached)
        {
            return new ValuePatternInformation(AutomationObject, cached);
        }
    }

    public class ValuePatternInformation : ElementInformationBase, IValuePatternInformation
    {
        public ValuePatternInformation(AutomationObjectBase automationObject, bool cached) : base(automationObject, cached)
        {
        }

        public bool IsReadOnly { get { return Get<bool>(ValuePatternIds.IsReadOnlyProperty); } }

        public string Value { get { return Get<string>(ValuePatternIds.ValueProperty); } }
    }
}
