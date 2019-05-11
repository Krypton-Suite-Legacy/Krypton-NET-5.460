﻿// *****************************************************************************
// BSD 3-Clause License (https://github.com/ComponentFactory/Krypton/blob/master/LICENSE)
//  © Component Factory Pty Ltd, 2006-2019, All rights reserved.
// The software and associated documentation supplied hereunder are the 
//  proprietary information of Component Factory Pty Ltd, 13 Swallows Close, 
//  Mornington, Vic 3931, Australia and are supplied subject to license terms.
// 
//  Modifications by Peter Wagner(aka Wagnerp) & Simon Coghlan(aka Smurf-IV) 2017 - 2019. All rights reserved. (https://github.com/Wagnerp/Krypton-NET-5.460)
//  Version 5.460.0.0  www.ComponentFactory.com
// *****************************************************************************

using System.ComponentModel;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Navigator
{
    /// <summary>
    /// Implement storage for normal and disable navigator appearance.
    /// </summary>
    public class PaletteNavigator : PaletteDoubleMetric
    {
        #region Instance Fields

        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the PaletteNavigatorNormabled class.
        /// </summary>
        /// <param name="redirect">Inheritence redirection instance.</param>
        /// <param name="needPaint">Delegate for notifying paint requests.</param>
        public PaletteNavigator(PaletteNavigatorRedirect redirect,
                                NeedPaintHandler needPaint)
            : base(redirect, needPaint)
        {
            // Create the palette storage
            PalettePage = new PalettePage(redirect.PalettePage, needPaint);
            HeaderGroup = new PaletteNavigatorHeaderGroup(redirect.HeaderGroup, redirect.HeaderGroup.HeaderPrimary, redirect.HeaderGroup.HeaderSecondary, redirect.HeaderGroup.HeaderBar, redirect.HeaderGroup.HeaderOverflow, needPaint);
            CheckButton = new PaletteTriple(redirect.CheckButton, needPaint);
            OverflowButton = new PaletteTriple(redirect.OverflowButton, needPaint);
            MiniButton = new PaletteTriple(redirect.MiniButton, needPaint);
            BorderEdge = new PaletteBorderEdge(redirect.BorderEdge, needPaint);
            Separator = new PaletteSeparatorPadding(redirect.Separator, redirect.Separator, needPaint);
            Tab = new PaletteTabTriple(redirect.Tab, needPaint);
            RibbonTab = new PaletteRibbonTabContent(redirect.RibbonTab.TabDraw, redirect.RibbonTab.TabDraw, redirect.RibbonTab.Content, needPaint);
        }
        #endregion

        #region IsDefault
        /// <summary>
        /// Gets a value indicating if all values are default.
        /// </summary>
        [Browsable(false)]
        public override bool IsDefault => (base.IsDefault &&
                                           PalettePage.IsDefault &&
                                           HeaderGroup.IsDefault &&
                                           CheckButton.IsDefault &&
                                           OverflowButton.IsDefault &&
                                           MiniButton.IsDefault &&
                                           BorderEdge.IsDefault &&
                                           Separator.IsDefault &&
                                           Tab.IsDefault &&
                                           RibbonTab.IsDefault);

        #endregion

        #region SetInherit
        /// <summary>
        /// Sets the inheritence parent.
        /// </summary>
        /// <param name="inheritNavigator">Source for inheriting.</param>
        public void SetInherit(PaletteNavigator inheritNavigator)
        {
            // Setup inheritance references for storage objects
            base.SetInherit(inheritNavigator);
            PalettePage.SetInherit(inheritNavigator.PalettePage);
            HeaderGroup.SetInherit(inheritNavigator.HeaderGroup);
            CheckButton.SetInherit(inheritNavigator.CheckButton);
            OverflowButton.SetInherit(inheritNavigator.OverflowButton);
            MiniButton.SetInherit(inheritNavigator.MiniButton);
            BorderEdge.SetInherit(inheritNavigator.BorderEdge);
            Separator.SetInherit(inheritNavigator.Separator);
            Tab.SetInherit(inheritNavigator.Tab);
            RibbonTab.SetInherit(inheritNavigator.RibbonTab.TabDraw, inheritNavigator.RibbonTab.TabDraw, inheritNavigator.RibbonTab.Content);
        }
        #endregion

        #region Back
        /// <summary>
        /// Gets access to the background palette details.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override PaletteBack Back => base.Back;


        /// <summary>
        /// Gets the background palette.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override IPaletteBack PaletteBack => base.PaletteBack;

        #endregion

        #region Border
        /// <summary>
        /// Gets access to the border palette details.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override PaletteBorder Border => base.Border;

        /// <summary>
        /// Gets the border palette.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override IPaletteBorder PaletteBorder => base.PaletteBorder;

        #endregion

        #region Panel
        /// <summary>
        /// Gets access to the panel palette details.
        /// </summary>
        [Category("Visuals")]
        [Description("Overrides for defining panel appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteBack Panel => base.Back;

        private bool ShouldSerializePanel()
        {
            return !base.Back.IsDefault;
        }
        #endregion

        #region CheckButton
        /// <summary>
        /// Gets access to the check button appearance entries.
        /// </summary>
        [Category("Visuals")]
        [Description("Overrides for defining check button appearance entries.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteTriple CheckButton { get; }

        private bool ShouldSerializeCheckButton()
        {
            return !CheckButton.IsDefault;
        }
        #endregion

        #region OverflowButton
        /// <summary>
        /// Gets access to the outlook overflow button appearance entries.
        /// </summary>
        [Category("Visuals")]
        [Description("Overrides for defining outlook overflow button appearance entries.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteTriple OverflowButton { get; }

        private bool ShouldSerializeOverflowButton()
        {
            return !OverflowButton.IsDefault;
        }
        #endregion

        #region MiniButton
        /// <summary>
        /// Gets access to the outlook mini button appearance entries.
        /// </summary>
        [Category("Visuals")]
        [Description("Overrides for defining outlook mini button appearance entries.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteTriple MiniButton { get; }

        private bool ShouldSerializeMiniButton()
        {
            return !MiniButton.IsDefault;
        }
        #endregion

        #region HeaderGroup
        /// <summary>
        /// Gets access to the header group appearance entries.
        /// </summary>
        [Category("Visuals")]
        [Description("Overrides for defining header group appearance entries.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteNavigatorHeaderGroup HeaderGroup { get; }

        private bool ShouldSerializeHeaderGroup()
        {
            return !HeaderGroup.IsDefault;
        }
        #endregion

        #region Page
        /// <summary>
        /// Gets access to the page appearance entries.
        /// </summary>
        [Category("Visuals")]
        [Description("Overrides for defining page appearance entries.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteBack Page => PalettePage.Back;

        private bool ShouldSerializePage()
        {
            return !PalettePage.Back.IsDefault;
        }
        #endregion

        #region BorderEdge
        /// <summary>
        /// Gets access to the border edge appearance entries.
        /// </summary>
        [Category("Visuals")]
        [Description("Overrides for defining border edge appearance entries.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteBorderEdge BorderEdge { get; }

        private bool ShouldSerializeBorderEdge()
        {
            return !BorderEdge.IsDefault;
        }
        #endregion

        #region Separator
        /// <summary>
        /// Get access to the overrides for defining separator appearance.
        /// </summary>
        [Category("Visuals")]
        [Description("Overrides for defining separator appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteSeparatorPadding Separator { get; }

        private bool ShouldSerializeSeparator()
        {
            return !Separator.IsDefault;
        }
        #endregion

        #region Tab
        /// <summary>
        /// Gets access to the tab appearance entries.
        /// </summary>
        [Category("Visuals")]
        [Description("Overrides for defining tab appearance entries.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteTabTriple Tab { get; }

        private bool ShouldSerializeTab()
        {
            return !Tab.IsDefault;
        }
        #endregion

        #region RibbonTab
        /// <summary>
        /// Gets access to the ribbon tab appearance entries.
        /// </summary>
        [Category("Visuals")]
        [Description("Overrides for defining ribbon tab appearance entries.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteRibbonTabContent RibbonTab { get; }

        private bool ShouldSerializeRibbonTab()
        {
            return !RibbonTab.IsDefault;
        }
        #endregion

        #region Internal
        internal PalettePage PalettePage { get; }

        #endregion
    }
}
