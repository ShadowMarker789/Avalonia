using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Avalonia.Win32;
using Avalonia.Win32.NativeInteropDecorations;

// developer-note: This file was partially generated, and then modified after the fact. 
// See GameInput.h located in C:\Program Files (x86)\Microsoft GDK\220601\GRDK\GameKit\Include 
// after installing the GDK development kit (Yes, the Game Development kit development kit)
// personal thanks goes out to Tanner Gooding and other developers for the ClangSharp project
// that was used to partially convert the relevant header files into C# code 

namespace Microsoft.Gdk.GameInput
{
#nullable enable

    // dev-note: I like how the online documentation for this enum is wrong 
    // see https://github.com/microsoft/GDK/issues/31 which I made earlier 
    public enum GameInputKind
    {
        GameInputKindUnknown = 0x00000000,
        GameInputKindRawDeviceReport = 0x00000001,
        GameInputKindControllerAxis = 0x00000002,
        GameInputKindControllerButton = 0x00000004,
        GameInputKindControllerSwitch = 0x00000008,
        GameInputKindController = 0x0000000E,
        GameInputKindKeyboard = 0x00000010,
        GameInputKindMouse = 0x00000020,
        GameInputKindTouch = 0x00000100,
        GameInputKindMotion = 0x00001000,
        GameInputKindArcadeStick = 0x00010000,
        GameInputKindFlightStick = 0x00020000,
        GameInputKindGamepad = 0x00040000,
        GameInputKindRacingWheel = 0x00080000,
        GameInputKindUiNavigation = 0x01000000,
        GameInputKindAny = 0x0FFFFFFF,
    }

    public enum GameInputEnumerationKind
    {
        GameInputNoEnumeration = 0,
        GameInputAsyncEnumeration = 1,
        GameInputBlockingEnumeration = 2,
    }

    public enum GameInputFocusPolicy
    {
        GameInputDefaultFocusPolicy = 0x00000000,
        GameInputDisableBackgroundInput = 0x00000001,
        GameInputExclusiveForegroundInput = 0x00000002,
    }

    public enum GameInputSwitchKind
    {
        GameInputUnknownSwitchKind = -1,
        GameInput2WaySwitch = 0,
        GameInput4WaySwitch = 1,
        GameInput8WaySwitch = 2,
    }

    public enum GameInputSwitchPosition
    {
        GameInputSwitchCenter = 0,
        GameInputSwitchUp = 1,
        GameInputSwitchUpRight = 2,
        GameInputSwitchRight = 3,
        GameInputSwitchDownRight = 4,
        GameInputSwitchDown = 5,
        GameInputSwitchDownLeft = 6,
        GameInputSwitchLeft = 7,
        GameInputSwitchUpLeft = 8,
    }

    public enum GameInputKeyboardKind
    {
        GameInputUnknownKeyboard = -1,
        GameInputAnsiKeyboard = 0,
        GameInputIsoKeyboard = 1,
        GameInputKsKeyboard = 2,
        GameInputAbntKeyboard = 3,
        GameInputJisKeyboard = 4,
    }

    public enum GameInputKeyboardLayout
    {
        GameInputUnknownLayout = -1,
        GameInputArabic101Layout = 0x00000401,
        GameInputBulgarianTypewriterLayout = 0x00000402,
        GameInputChineseTraditionalUSKeyboardLayout = 0x00000404,
        GameInputCzechLayout = 0x00000405,
        GameInputDanishLayout = 0x00000406,
        GameInputGermanLayout = 0x00000407,
        GameInputGreekLayout = 0x00000408,
        GameInputUnitedStatesLayout = 0x00000409,
        GameInputSpanishLayout = 0x0000040A,
        GameInputFinnishLayout = 0x0000040B,
        GameInputFrenchLayout = 0x0000040C,
        GameInputHebrewLayout = 0x0000040D,
        GameInputHungarianLayout = 0x0000040E,
        GameInputIcelandicLayout = 0x0000040F,
        GameInputItalianLayout = 0x00000410,
        GameInputJapaneseLayout = 0x00000411,
        GameInputKoreanLayout = 0x00000412,
        GameInputDutchLayout = 0x00000413,
        GameInputNorwegianLayout = 0x00000414,
        GameInputPolishProgrammersLayout = 0x00000415,
        GameInputPortugueseBrazilianAbntLayout = 0x00000416,
        GameInputRomanianLegacyLayout = 0x00000418,
        GameInputRussianLayout = 0x00000419,
        GameInputStandardLayout = 0x0000041A,
        GameInputSlovakLayout = 0x0000041B,
        GameInputAlbanianLayout = 0x0000041C,
        GameInputSwedishLayout = 0x0000041D,
        GameInputThaiKedmaneeLayout = 0x0000041E,
        GameInputTurkishQLayout = 0x0000041F,
        GameInputUrduLayout = 0x00000420,
        GameInputUkrainianLayout = 0x00000422,
        GameInputBelarusianLayout = 0x00000423,
        GameInputSlovenianLayout = 0x00000424,
        GameInputEstonianLayout = 0x00000425,
        GameInputLatvianLayout = 0x00000426,
        GameInputLithuanianIbmLayout = 0x00000427,
        GameInputTajikLayout = 0x00000428,
        GameInputPersianLayout = 0x00000429,
        GameInputVietnameseLayout = 0x0000042A,
        GameInputArmenianEasternLayout = 0x0000042B,
        GameInputAzeriLatinLayout = 0x0000042C,
        GameInputSorbianStandardLegacyLayout = 0x0000042E,
        GameInputMacedonianFyromLayout = 0x0000042F,
        GameInputSetswanaLayout = 0x00000432,
        GameInputGeorgianLayout = 0x00000437,
        GameInputFaeroeseLayout = 0x00000438,
        GameInputDevanagariInscriptLayout = 0x00000439,
        GameInputMaltese47KeyLayout = 0x0000043A,
        GameInputNorwegianWithSamiLayout = 0x0000043B,
        GameInputKazakhLayout = 0x0000043F,
        GameInputKyrgyzCyrillicLayout = 0x00000440,
        GameInputTurkmenLayout = 0x00000442,
        GameInputTatarLegacyLayout = 0x00000444,
        GameInputBengaliLayout = 0x00000445,
        GameInputPunjabiLayout = 0x00000446,
        GameInputGujaratiLayout = 0x00000447,
        GameInputOriyaLayout = 0x00000448,
        GameInputTamilLayout = 0x00000449,
        GameInputTeluguLayout = 0x0000044A,
        GameInputKannadaLayout = 0x0000044B,
        GameInputMalayalamLayout = 0x0000044C,
        GameInputAssameseInscriptLayout = 0x0000044D,
        GameInputMarathiLayout = 0x0000044E,
        GameInputMongolianCyrillicLayout = 0x00000450,
        GameInputTibetanPrcLayout = 0x00000451,
        GameInputUnitedKingdomExtendedLayout = 0x00000452,
        GameInputKhmerLayout = 0x00000453,
        GameInputLaoLayout = 0x00000454,
        GameInputSyriacLayout = 0x0000045A,
        GameInputSinhalaLayout = 0x0000045B,
        GameInputCherokeeNationLayout = 0x0000045C,
        GameInputNepaliLayout = 0x00000461,
        GameInputPashtoAfghanistanLayout = 0x00000463,
        GameInputDivehiPhoneticLayout = 0x00000465,
        GameInputHausaLayout = 0x00000468,
        GameInputYorubaLayout = 0x0000046A,
        GameInputSesothoSaLeboaLayout = 0x0000046C,
        GameInputBashkirLayout = 0x0000046D,
        GameInputLuxembourgishLayout = 0x0000046E,
        GameInputGreenlandicLayout = 0x0000046F,
        GameInputIgboLayout = 0x00000470,
        GameInputGuaraniLayout = 0x00000474,
        GameInputHawaiianLayout = 0x00000475,
        GameInputUyghurLegacyLayout = 0x00000480,
        GameInputMaoriLayout = 0x00000481,
        GameInputSakhaLayout = 0x00000485,
        GameInputWolofLayout = 0x00000488,
        GameInputCentralKurdishLayout = 0x00000492,
        GameInputChineseSimplifiedUsKeyboardLayout = 0x00000804,
        GameInputSwissGermanLayout = 0x00000807,
        GameInputUnitedKingdomLayout = 0x00000809,
        GameInputLatinAmericanLayout = 0x0000080A,
        GameInputBelgianFrenchLayout = 0x0000080C,
        GameInputBelgianPeriodLayout = 0x00000813,
        GameInputPortugueseLayout = 0x00000816,
        GameInputSerbianLatinLayout = 0x0000081A,
        GameInputAzeriCyrillicLayout = 0x0000082C,
        GameInputSwedishWithSamiLayout = 0x0000083B,
        GameInputUzbekCyrillicLayout = 0x00000843,
        GameInputMongolianMongolianScriptLayout = 0x00000850,
        GameInputInuktitutLatinLayout = 0x0000085D,
        GameInputCentralAtlasTamazightLayout = 0x0000085F,
        GameInputChineseTraditionalHongKongSarUsKeyboardLayout = 0x00000C04,
        GameInputCanadianFrenchLegacyLayout = 0x00000C0C,
        GameInputSerbianCyrillicLayout = 0x00000C1A,
        GameInputDzongkhaLayout = 0x00000C51,
        GameInputChineseSimplifiedSingaporeUsKeyboardLayout = 0x00001004,
        GameInputCanadianFrenchLayout = 0x00001009,
        GameInputSwissFrenchLayout = 0x0000100C,
        GameInputTifinaghBasicLayout = 0x0000105F,
        GameInputChineseTraditionalMacaoSarUsKeyboardLayout = 0x00001404,
        GameInputIrishLayout = 0x00001809,
        GameInputBosnianCyrillicLayout = 0x0000201A,
        GameInputIndiaLayout = 0x00004009,
        GameInputArabic102Layout = 0x00010401,
        GameInputBulgarianLatinLayout = 0x00010402,
        GameInputCzechQwertyLayout = 0x00010405,
        GameInputGermanIbmLayout = 0x00010407,
        GameInputGreek220Layout = 0x00010408,
        GameInputUnitedStatesDvorakLayout = 0x00010409,
        GameInputSpanishVariationLayout = 0x0001040A,
        GameInputHungarian101KeyLayout = 0x0001040E,
        GameInputItalian142Layout = 0x00010410,
        GameInputPolish214Layout = 0x00010415,
        GameInputPortugueseBrazilianAbnt2Layout = 0x00010416,
        GameInputRomanianStandardLayout = 0x00010418,
        GameInputRussianTypewriterLayout = 0x00010419,
        GameInputSlovakQwertyLayout = 0x0001041B,
        GameInputThaiPattachoteLayout = 0x0001041E,
        GameInputTurkishFLayout = 0x0001041F,
        GameInputLatvianQwertyLayout = 0x00010426,
        GameInputLithuanianLayout = 0x00010427,
        GameInputArmenianWesternLayout = 0x0001042B,
        GameInputAzerbaijaniStandardLayout = 0x0001042C,
        GameInputSorbianExtendedLayout = 0x0001042E,
        GameInputMacedonianFyromStandardLayout = 0x0001042F,
        GameInputGeorgianQwertyLayout = 0x00010437,
        GameInputHindiTraditionalLayout = 0x00010439,
        GameInputMaltese48KeyLayout = 0x0001043A,
        GameInputSamiExtendedNorwayLayout = 0x0001043B,
        GameInputTatarLayout = 0x00010444,
        GameInputBengaliInscriptLegacyLayout = 0x00010445,
        GameInputTibetanPrcUpdatedLayout = 0x00010451,
        GameInputKhmerNidaLayout = 0x00010453,
        GameInputSyriacPhoneticLayout = 0x0001045A,
        GameInputSinhalaWij9Layout = 0x0001045B,
        GameInputCherokeeNationPhoneticLayout = 0x0001045C,
        GameInputInuktitutNaqittautLayout = 0x0001045D,
        GameInputDivehiTypewriterLayout = 0x00010465,
        GameInputUyghurLayout = 0x00010480,
        GameInputBelgianCommaLayout = 0x0001080C,
        GameInputFinnishWithSamiLayout = 0x0001083B,
        GameInputTraditionalMongolianStandardLayout = 0x00010850,
        GameInputMyanmarPhoneticOrderLayout = 0x00010C00,
        GameInputCanadianMultilingualStandardLayout = 0x00011009,
        GameInputTifinaghFullLayout = 0x0001105F,
        GameInputGaelicLayout = 0x00011809,
        GameInputArabic102AzertyLayout = 0x00020401,
        GameInputBulgarianPhoneticLayout = 0x00020402,
        GameInputCzechProgrammersLayout = 0x00020405,
        GameInputGreek319Layout = 0x00020408,
        GameInputUnitedStatesInternationalLayout = 0x00020409,
        GameInputHebrewStandardLayout = 0x0002040D,
        GameInputRomanianProgrammersLayout = 0x00020418,
        GameInputRussianMnemonicLayout = 0x00020419,
        GameInputThaiKedmaneeNonShiftLockLayout = 0x0002041E,
        GameInputUkrainianEnhancedLayout = 0x00020422,
        GameInputLatvianStandardLayout = 0x00020426,
        GameInputLithuanianStandardLayout = 0x00020427,
        GameInputArmenianPhoneticLayout = 0x0002042B,
        GameInputSorbianStandardLayout = 0x0002042E,
        GameInputGeorgianErgonomicLayout = 0x00020437,
        GameInputBengaliInscriptLayout = 0x00020445,
        GameInputTamil99Layout = 0x00020449,
        GameInputSamiExtendedFinlandSwedenLayout = 0x0002083B,
        GameInputNewTaiLueLayout = 0x00020C00,
        GameInputBulgarianLayout = 0x00030402,
        GameInputGreek220LatinLayout = 0x00030408,
        GameInputUnitedStatesDvorakForLeftHandLayout = 0x00030409,
        GameInputThaiPattachoteNonShiftLockLayout = 0x0003041E,
        GameInputArmenianTypewriterLayout = 0x0003042B,
        GameInputGeorgianMinistryOfEducationAndScienceSchoolsLayout = 0x00030437,
        GameInputTaiLeLayout = 0x00030C00,
        GameInputBulgarianPhoneticTraditionalLayout = 0x00040402,
        GameInputGreek319LatinLayout = 0x00040408,
        GameInputUnitedStatesDvorakForRightHandLayout = 0x00040409,
        GameInputGeorgianOldAlphabetsLayout = 0x00040437,
        GameInputOghamLayout = 0x00040C00,
        GameInputGreekLatinLayout = 0x00050408,
        GameInputUsEnglishTableForIbmArabic238LLayout = 0x00050409,
        GameInputPersianStandardLayout = 0x00050429,
        GameInputGreekPolytonicLayout = 0x00060408,
        GameInputLisuBasicLayout = 0x00070C00,
        GameInputLisuStandardLayout = 0x00080C00,
        GameInputNKoLayout = 0x00090C00,
        GameInputPhagsPaLayout = 0x000A0C00,
        GameInputBugineseLayout = 0x000B0C00,
        GameInputGothicLayout = 0x000C0C00,
        GameInputOlChikiLayout = 0x000D0C00,
        GameInputOsmanyaLayout = 0x000E0C00,
        GameInputOldItalicLayout = 0x000F0C00,
        GameInputSoraLayout = 0x00100C00,
        GameInputJavaneseLayout = 0x00110C00,
        GameInputFutharkLayout = 0x00120C00,
        GameInputMyanmarVisualOrderLayout = 0x00130C00,
        GameInputADLaMLayout = 0x00140C00,
        GameInputOsageLayout = 0x00150C00,
    }

    public enum GameInputMouseButtons
    {
        GameInputMouseNone = 0x00000000,
        GameInputMouseLeftButton = 0x00000001,
        GameInputMouseRightButton = 0x00000002,
        GameInputMouseMiddleButton = 0x00000004,
        GameInputMouseButton4 = 0x00000008,
        GameInputMouseButton5 = 0x00000010,
        GameInputMouseWheelTiltLeft = 0x00000020,
        GameInputMouseWheelTiltRight = 0x00000040,
    }

    public enum GameInputTouchShape
    {
        GameInputTouchShapeUnknown = -1,
        GameInputTouchShapePoint = 0,
        GameInputTouchShape1DLinear = 1,
        GameInputTouchShape1DRadial = 2,
        GameInputTouchShape1DIrregular = 3,
        GameInputTouchShape2DRectangular = 4,
        GameInputTouchShape2DElliptical = 5,
        GameInputTouchShape2DIrregular = 6,
    }

    public enum GameInputMotionAccuracy
    {
        GameInputMotionAccuracyUnknown = -1,
        GameInputMotionUnavailable = 0,
        GameInputMotionUnreliable = 1,
        GameInputMotionApproximate = 2,
        GameInputMotionAccurate = 3,
    }

    public enum GameInputArcadeStickButtons
    {
        GameInputArcadeStickNone = 0x00000000,
        GameInputArcadeStickMenu = 0x00000001,
        GameInputArcadeStickView = 0x00000002,
        GameInputArcadeStickUp = 0x00000004,
        GameInputArcadeStickDown = 0x00000008,
        GameInputArcadeStickLeft = 0x00000010,
        GameInputArcadeStickRight = 0x00000020,
        GameInputArcadeStickAction1 = 0x00000040,
        GameInputArcadeStickAction2 = 0x00000080,
        GameInputArcadeStickAction3 = 0x00000100,
        GameInputArcadeStickAction4 = 0x00000200,
        GameInputArcadeStickAction5 = 0x00000400,
        GameInputArcadeStickAction6 = 0x00000800,
        GameInputArcadeStickSpecial1 = 0x00001000,
        GameInputArcadeStickSpecial2 = 0x00002000,
    }

    public enum GameInputFlightStickButtons
    {
        GameInputFlightStickNone = 0x00000000,
        GameInputFlightStickMenu = 0x00000001,
        GameInputFlightStickView = 0x00000002,
        GameInputFlightStickFirePrimary = 0x00000004,
        GameInputFlightStickFireSecondary = 0x00000008,
    }

    public enum GameInputGamepadButtons
    {
        GameInputGamepadNone = 0x00000000,
        GameInputGamepadMenu = 0x00000001,
        GameInputGamepadView = 0x00000002,
        GameInputGamepadA = 0x00000004,
        GameInputGamepadB = 0x00000008,
        GameInputGamepadX = 0x00000010,
        GameInputGamepadY = 0x00000020,
        GameInputGamepadDPadUp = 0x00000040,
        GameInputGamepadDPadDown = 0x00000080,
        GameInputGamepadDPadLeft = 0x00000100,
        GameInputGamepadDPadRight = 0x00000200,
        GameInputGamepadLeftShoulder = 0x00000400,
        GameInputGamepadRightShoulder = 0x00000800,
        GameInputGamepadLeftThumbstick = 0x00001000,
        GameInputGamepadRightThumbstick = 0x00002000,
    }

    public enum GameInputRacingWheelButtons
    {
        GameInputRacingWheelNone = 0x00000000,
        GameInputRacingWheelMenu = 0x00000001,
        GameInputRacingWheelView = 0x00000002,
        GameInputRacingWheelPreviousGear = 0x00000004,
        GameInputRacingWheelNextGear = 0x00000008,
        GameInputRacingWheelDpadUp = 0x00000010,
        GameInputRacingWheelDpadDown = 0x00000020,
        GameInputRacingWheelDpadLeft = 0x00000040,
        GameInputRacingWheelDpadRight = 0x00000080,
    }

    public enum GameInputUiNavigationButtons
    {
        GameInputUiNavigationNone = 0x00000000,
        GameInputUiNavigationMenu = 0x00000001,
        GameInputUiNavigationView = 0x00000002,
        GameInputUiNavigationAccept = 0x00000004,
        GameInputUiNavigationCancel = 0x00000008,
        GameInputUiNavigationUp = 0x00000010,
        GameInputUiNavigationDown = 0x00000020,
        GameInputUiNavigationLeft = 0x00000040,
        GameInputUiNavigationRight = 0x00000080,
        GameInputUiNavigationContext1 = 0x00000100,
        GameInputUiNavigationContext2 = 0x00000200,
        GameInputUiNavigationContext3 = 0x00000400,
        GameInputUiNavigationContext4 = 0x00000800,
        GameInputUiNavigationPageUp = 0x00001000,
        GameInputUiNavigationPageDown = 0x00002000,
        GameInputUiNavigationPageLeft = 0x00004000,
        GameInputUiNavigationPageRight = 0x00008000,
        GameInputUiNavigationScrollUp = 0x00010000,
        GameInputUiNavigationScrollDown = 0x00020000,
        GameInputUiNavigationScrollLeft = 0x00040000,
        GameInputUiNavigationScrollRight = 0x00080000,
    }

    public enum GameInputDeviceStatus
    {
        GameInputDeviceNoStatus = 0x00000000,
        GameInputDeviceConnected = 0x00000001,
        GameInputDeviceInputEnabled = 0x00000002,
        GameInputDeviceOutputEnabled = 0x00000004,
        GameInputDeviceRawIoEnabled = 0x00000008,
        GameInputDeviceAudioCapture = 0x00000010,
        GameInputDeviceAudioRender = 0x00000020,
        GameInputDeviceSynchronized = 0x00000040,
        GameInputDeviceWireless = 0x00000080,
        GameInputDeviceUserIdle = 0x00100000,
        GameInputDeviceAnyStatus = 0x00FFFFFF,
    }

    public enum GameInputBatteryStatus
    {
        GameInputBatteryUnknown = -1,
        GameInputBatteryNotPresent = 0,
        GameInputBatteryDischarging = 1,
        GameInputBatteryIdle = 2,
        GameInputBatteryCharging = 3,
    }

    public enum GameInputDeviceFamily
    {
        GameInputFamilyVirtual = -1,
        GameInputFamilyAggregate = 0,
        GameInputFamilyXboxOne = 1,
        GameInputFamilyXbox360 = 2,
        GameInputFamilyHid = 3,
        GameInputFamilyI8042 = 4,
    }

    public enum GameInputDeviceCapabilities
    {
        GameInputDeviceCapabilityNone = 0x00000000,
        GameInputDeviceCapabilityAudio = 0x00000001,
        GameInputDeviceCapabilityPluginModule = 0x00000002,
        GameInputDeviceCapabilityPowerOff = 0x00000004,
        GameInputDeviceCapabilitySynchronization = 0x00000008,
        GameInputDeviceCapabilityWireless = 0x00000010,
    }

    public enum GameInputRawDeviceReportKind
    {
        GameInputRawInputReport = 0,
        GameInputRawOutputReport = 1,
        GameInputRawFeatureReport = 2,
    }

    public enum GameInputRawDeviceReportItemFlags
    {
        GameInputDefaultItem = 0x00000000,
        GameInputConstantItem = 0x00000001,
        GameInputArrayItem = 0x00000002,
        GameInputRelativeItem = 0x00000004,
        GameInputWraparoundItem = 0x00000008,
        GameInputNonlinearItem = 0x00000010,
        GameInputStableItem = 0x00000020,
        GameInputNullableItem = 0x00000040,
        GameInputVolatileItem = 0x00000080,
        GameInputBufferedItem = 0x00000100,
    }

    public enum GameInputRawDeviceItemCollectionKind
    {
        GameInputUnknownItemCollection = -1,
        GameInputPhysicalItemCollection = 0,
        GameInputApplicationItemCollection = 1,
        GameInputLogicalItemCollection = 2,
        GameInputReportItemCollection = 3,
        GameInputNamedArrayItemCollection = 4,
        GameInputUsageSwitchItemCollection = 5,
        GameInputUsageModifierItemCollection = 6,
    }

    public enum GameInputRawDevicePhysicalUnitKind
    {
        GameInputPhysicalUnitUnknown = -1,
        GameInputPhysicalUnitNone = 0,
        GameInputPhysicalUnitTime = 1,
        GameInputPhysicalUnitFrequency = 2,
        GameInputPhysicalUnitLength = 3,
        GameInputPhysicalUnitVelocity = 4,
        GameInputPhysicalUnitAcceleration = 5,
        GameInputPhysicalUnitMass = 6,
        GameInputPhysicalUnitMomentum = 7,
        GameInputPhysicalUnitForce = 8,
        GameInputPhysicalUnitPressure = 9,
        GameInputPhysicalUnitAngle = 10,
        GameInputPhysicalUnitAngularVelocity = 11,
        GameInputPhysicalUnitAngularAcceleration = 12,
        GameInputPhysicalUnitAngularMass = 13,
        GameInputPhysicalUnitAngularMomentum = 14,
        GameInputPhysicalUnitAngularTorque = 15,
        GameInputPhysicalUnitElectricCurrent = 16,
        GameInputPhysicalUnitElectricCharge = 17,
        GameInputPhysicalUnitElectricPotential = 18,
        GameInputPhysicalUnitEnergy = 19,
        GameInputPhysicalUnitPower = 20,
        GameInputPhysicalUnitTemperature = 21,
        GameInputPhysicalUnitLuminousIntensity = 22,
        GameInputPhysicalUnitLuminousFlux = 23,
        GameInputPhysicalUnitIlluminance = 24,
    }

    public enum GameInputLabel
    {
        GameInputLabelUnknown = -1,
        GameInputLabelNone = 0,
        GameInputLabelXboxGuide = 1,
        GameInputLabelXboxBack = 2,
        GameInputLabelXboxStart = 3,
        GameInputLabelXboxMenu = 4,
        GameInputLabelXboxView = 5,
        GameInputLabelXboxA = 7,
        GameInputLabelXboxB = 8,
        GameInputLabelXboxX = 9,
        GameInputLabelXboxY = 10,
        GameInputLabelXboxDPadUp = 11,
        GameInputLabelXboxDPadDown = 12,
        GameInputLabelXboxDPadLeft = 13,
        GameInputLabelXboxDPadRight = 14,
        GameInputLabelXboxLeftShoulder = 15,
        GameInputLabelXboxLeftTrigger = 16,
        GameInputLabelXboxLeftStickButton = 17,
        GameInputLabelXboxRightShoulder = 18,
        GameInputLabelXboxRightTrigger = 19,
        GameInputLabelXboxRightStickButton = 20,
        GameInputLabelXboxPaddle1 = 21,
        GameInputLabelXboxPaddle2 = 22,
        GameInputLabelXboxPaddle3 = 23,
        GameInputLabelXboxPaddle4 = 24,
        GameInputLabelLetterA = 25,
        GameInputLabelLetterB = 26,
        GameInputLabelLetterC = 27,
        GameInputLabelLetterD = 28,
        GameInputLabelLetterE = 29,
        GameInputLabelLetterF = 30,
        GameInputLabelLetterG = 31,
        GameInputLabelLetterH = 32,
        GameInputLabelLetterI = 33,
        GameInputLabelLetterJ = 34,
        GameInputLabelLetterK = 35,
        GameInputLabelLetterL = 36,
        GameInputLabelLetterM = 37,
        GameInputLabelLetterN = 38,
        GameInputLabelLetterO = 39,
        GameInputLabelLetterP = 40,
        GameInputLabelLetterQ = 41,
        GameInputLabelLetterR = 42,
        GameInputLabelLetterS = 43,
        GameInputLabelLetterT = 44,
        GameInputLabelLetterU = 45,
        GameInputLabelLetterV = 46,
        GameInputLabelLetterW = 47,
        GameInputLabelLetterX = 48,
        GameInputLabelLetterY = 49,
        GameInputLabelLetterZ = 50,
        GameInputLabelNumber0 = 51,
        GameInputLabelNumber1 = 52,
        GameInputLabelNumber2 = 53,
        GameInputLabelNumber3 = 54,
        GameInputLabelNumber4 = 55,
        GameInputLabelNumber5 = 56,
        GameInputLabelNumber6 = 57,
        GameInputLabelNumber7 = 58,
        GameInputLabelNumber8 = 59,
        GameInputLabelNumber9 = 60,
        GameInputLabelArrowUp = 61,
        GameInputLabelArrowUpRight = 62,
        GameInputLabelArrowRight = 63,
        GameInputLabelArrowDownRight = 64,
        GameInputLabelArrowDown = 65,
        GameInputLabelArrowDownLLeft = 66,
        GameInputLabelArrowLeft = 67,
        GameInputLabelArrowUpLeft = 68,
        GameInputLabelArrowUpDown = 69,
        GameInputLabelArrowLeftRight = 70,
        GameInputLabelArrowUpDownLeftRight = 71,
        GameInputLabelArrowClockwise = 72,
        GameInputLabelArrowCounterClockwise = 73,
        GameInputLabelArrowReturn = 74,
        GameInputLabelIconBranding = 75,
        GameInputLabelIconHome = 76,
        GameInputLabelIconMenu = 77,
        GameInputLabelIconCross = 78,
        GameInputLabelIconCircle = 79,
        GameInputLabelIconSquare = 80,
        GameInputLabelIconTriangle = 81,
        GameInputLabelIconStar = 82,
        GameInputLabelIconDPadUp = 83,
        GameInputLabelIconDPadDown = 84,
        GameInputLabelIconDPadLeft = 85,
        GameInputLabelIconDPadRight = 86,
        GameInputLabelIconDialClockwise = 87,
        GameInputLabelIconDialCounterClockwise = 88,
        GameInputLabelIconSliderLeftRight = 89,
        GameInputLabelIconSliderUpDown = 90,
        GameInputLabelIconWheelUpDown = 91,
        GameInputLabelIconPlus = 92,
        GameInputLabelIconMinus = 93,
        GameInputLabelIconSuspension = 94,
        GameInputLabelHome = 95,
        GameInputLabelGuide = 96,
        GameInputLabelMode = 97,
        GameInputLabelSelect = 98,
        GameInputLabelMenu = 99,
        GameInputLabelView = 100,
        GameInputLabelBack = 101,
        GameInputLabelStart = 102,
        GameInputLabelOptions = 103,
        GameInputLabelShare = 104,
        GameInputLabelUp = 105,
        GameInputLabelDown = 106,
        GameInputLabelLeft = 107,
        GameInputLabelRight = 108,
        GameInputLabelLB = 109,
        GameInputLabelLT = 110,
        GameInputLabelLSB = 111,
        GameInputLabelL1 = 112,
        GameInputLabelL2 = 113,
        GameInputLabelL3 = 114,
        GameInputLabelRB = 115,
        GameInputLabelRT = 116,
        GameInputLabelRSB = 117,
        GameInputLabelR1 = 118,
        GameInputLabelR2 = 119,
        GameInputLabelR3 = 120,
        GameInputLabelP1 = 121,
        GameInputLabelP2 = 122,
        GameInputLabelP3 = 123,
        GameInputLabelP4 = 124,
    }

    public enum GameInputLocation
    {
        GameInputLocationUnknown = -1,
        GameInputLocationChassis = 0,
        GameInputLocationDisplay = 1,
        GameInputLocationAxis = 2,
        GameInputLocationButton = 3,
        GameInputLocationSwitch = 4,
        GameInputLocationKey = 5,
        GameInputLocationTouchPad = 6,
    }

    public enum GameInputFeedbackAxes
    {
        GameInputFeedbackAxisNone = 0x00000000,
        GameInputFeedbackAxisLinearX = 0x00000001,
        GameInputFeedbackAxisLinearY = 0x00000002,
        GameInputFeedbackAxisLinearZ = 0x00000004,
        GameInputFeedbackAxisAngularX = 0x00000008,
        GameInputFeedbackAxisAngularY = 0x00000010,
        GameInputFeedbackAxisAngularZ = 0x00000020,
        GameInputFeedbackAxisNormal = 0x00000040,
    }

    public enum GameInputFeedbackEffectState
    {
        GameInputFeedbackStopped = 0,
        GameInputFeedbackRunning = 1,
        GameInputFeedbackPaused = 2,
    }

    public enum GameInputForceFeedbackEffectKind
    {
        GameInputForceFeedbackConstant = 0,
        GameInputForceFeedbackRamp = 1,
        GameInputForceFeedbackSineWave = 2,
        GameInputForceFeedbackSquareWave = 3,
        GameInputForceFeedbackTriangleWave = 4,
        GameInputForceFeedbackSawtoothUpWave = 5,
        GameInputForceFeedbackSawtoothDownWave = 6,
        GameInputForceFeedbackSpring = 7,
        GameInputForceFeedbackFriction = 8,
        GameInputForceFeedbackDamper = 9,
        GameInputForceFeedbackInertia = 10,
    }

    public enum GameInputRumbleMotors
    {
        GameInputRumbleNone = 0x00000000,
        GameInputRumbleLowFrequency = 0x00000001,
        GameInputRumbleHighFrequency = 0x00000002,
        GameInputRumbleLeftTrigger = 0x00000004,
        GameInputRumbleRightTrigger = 0x00000008,
    }

    public partial struct GameInputKeyState
    {
        [NativeTypeName("uint32_t")]
        public uint scanCode;

        [NativeTypeName("uint32_t")]
        public uint codePoint;

        [NativeTypeName("uint8_t")]
        public byte virtualKey;

        [NativeTypeName("bool")]
        public byte isDeadKey;
    }

    public partial struct GameInputMouseState
    {
        public GameInputMouseButtons buttons;

        [NativeTypeName("int64_t")]
        public long positionX;

        [NativeTypeName("int64_t")]
        public long positionY;

        [NativeTypeName("int64_t")]
        public long wheelX;

        [NativeTypeName("int64_t")]
        public long wheelY;
    }

    public partial struct GameInputTouchState
    {
        [NativeTypeName("uint64_t")]
        public ulong touchId;

        [NativeTypeName("uint32_t")]
        public uint sensorIndex;

        public float positionX;

        public float positionY;

        public float pressure;

        public float proximity;

        public float contactRectTop;

        public float contactRectLeft;

        public float contactRectRight;

        public float contactRectBottom;
    }

    public partial struct GameInputMotionState
    {
        public float accelerationX;

        public float accelerationY;

        public float accelerationZ;

        public float angularVelocityX;

        public float angularVelocityY;

        public float angularVelocityZ;

        public float magneticFieldX;

        public float magneticFieldY;

        public float magneticFieldZ;

        public float orientationW;

        public float orientationX;

        public float orientationY;

        public float orientationZ;

        public GameInputMotionAccuracy magnetometerAccuracy;

        public GameInputMotionAccuracy orientationAccuracy;
    }

    public partial struct GameInputArcadeStickState
    {
        public GameInputArcadeStickButtons buttons;
    }

    public partial struct GameInputFlightStickState
    {
        public GameInputFlightStickButtons buttons;

        public GameInputSwitchPosition hatSwitch;

        public float roll;

        public float pitch;

        public float yaw;

        public float throttle;
    }

    public partial struct GameInputGamepadState
    {
        public GameInputGamepadButtons buttons;

        public float leftTrigger;

        public float rightTrigger;

        public float leftThumbstickX;

        public float leftThumbstickY;

        public float rightThumbstickX;

        public float rightThumbstickY;
    }

    public partial struct GameInputRacingWheelState
    {
        public GameInputRacingWheelButtons buttons;

        [NativeTypeName("int32_t")]
        public int patternShifterGear;

        public float wheel;

        public float throttle;

        public float brake;

        public float clutch;

        public float handbrake;
    }

    public partial struct GameInputUiNavigationState
    {
        public GameInputUiNavigationButtons buttons;
    }

    public partial struct GameInputBatteryState
    {
        public float chargeRate;

        public float maxChargeRate;

        public float remainingCapacity;

        public float fullChargeCapacity;

        public GameInputBatteryStatus status;
    }

    public unsafe partial struct GameInputString
    {
        [NativeTypeName("uint32_t")]
        public uint sizeInBytes;

        [NativeTypeName("uint32_t")]
        public uint codePointCount;

        [NativeTypeName("const char *")]
        public sbyte* data;
    }

    public partial struct GameInputUsage
    {
        [NativeTypeName("uint16_t")]
        public ushort page;

        [NativeTypeName("uint16_t")]
        public ushort id;
    }

    public partial struct GameInputVersion
    {
        [NativeTypeName("uint16_t")]
        public ushort major;

        [NativeTypeName("uint16_t")]
        public ushort minor;

        [NativeTypeName("uint16_t")]
        public ushort build;

        [NativeTypeName("uint16_t")]
        public ushort revision;
    }

    public unsafe partial struct GameInputRawDeviceItemCollectionInfo
    {
        public GameInputRawDeviceItemCollectionKind kind;

        [NativeTypeName("uint32_t")]
        public uint childCount;

        [NativeTypeName("uint32_t")]
        public uint siblingCount;

        [NativeTypeName("uint32_t")]
        public uint usageCount;

        [NativeTypeName("const GameInputUsage *")]
        public GameInputUsage* usages;

        [NativeTypeName("const struct GameInputRawDeviceItemCollectionInfo *")]
        public GameInputRawDeviceItemCollectionInfo* parent;

        [NativeTypeName("const struct GameInputRawDeviceItemCollectionInfo *")]
        public GameInputRawDeviceItemCollectionInfo* firstSibling;

        [NativeTypeName("const struct GameInputRawDeviceItemCollectionInfo *")]
        public GameInputRawDeviceItemCollectionInfo* previousSibling;

        [NativeTypeName("const struct GameInputRawDeviceItemCollectionInfo *")]
        public GameInputRawDeviceItemCollectionInfo* nextSibling;

        [NativeTypeName("const struct GameInputRawDeviceItemCollectionInfo *")]
        public GameInputRawDeviceItemCollectionInfo* lastSibling;

        [NativeTypeName("const struct GameInputRawDeviceItemCollectionInfo *")]
        public GameInputRawDeviceItemCollectionInfo* firstChild;

        [NativeTypeName("const struct GameInputRawDeviceItemCollectionInfo *")]
        public GameInputRawDeviceItemCollectionInfo* lastChild;
    }

    public unsafe partial struct GameInputRawDeviceReportItemInfo
    {
        [NativeTypeName("uint32_t")]
        public uint bitOffset;

        [NativeTypeName("uint32_t")]
        public uint bitSize;

        [NativeTypeName("int64_t")]
        public long logicalMin;

        [NativeTypeName("int64_t")]
        public long logicalMax;

        public double physicalMin;

        public double physicalMax;

        public GameInputRawDevicePhysicalUnitKind physicalUnits;

        [NativeTypeName("uint32_t")]
        public uint rawPhysicalUnits;

        [NativeTypeName("int32_t")]
        public int rawPhysicalUnitsExponent;

        public GameInputRawDeviceReportItemFlags flags;

        [NativeTypeName("uint32_t")]
        public uint usageCount;

        [NativeTypeName("const GameInputUsage *")]
        public GameInputUsage* usages;

        [NativeTypeName("const GameInputRawDeviceItemCollectionInfo *")]
        public GameInputRawDeviceItemCollectionInfo* collection;

        [NativeTypeName("const GameInputString *")]
        public GameInputString* itemString;
    }

    public unsafe partial struct GameInputRawDeviceReportInfo
    {
        public GameInputRawDeviceReportKind kind;

        [NativeTypeName("uint32_t")]
        public uint id;

        [NativeTypeName("uint32_t")]
        public uint size;

        [NativeTypeName("uint32_t")]
        public uint itemCount;

        [NativeTypeName("const GameInputRawDeviceReportItemInfo *")]
        public GameInputRawDeviceReportItemInfo* items;
    }

    public unsafe partial struct GameInputControllerAxisInfo
    {
        public GameInputKind mappedInputKinds;

        public GameInputLabel label;

        [NativeTypeName("bool")]
        public byte isContinuous;

        [NativeTypeName("bool")]
        public byte isNonlinear;

        [NativeTypeName("bool")]
        public byte isQuantized;

        [NativeTypeName("bool")]
        public byte hasRestValue;

        public float restValue;

        [NativeTypeName("uint64_t")]
        public ulong resolution;

        [NativeTypeName("uint16_t")]
        public ushort legacyDInputIndex;

        [NativeTypeName("uint16_t")]
        public ushort legacyHidIndex;

        [NativeTypeName("uint32_t")]
        public uint rawReportIndex;

        [NativeTypeName("const GameInputRawDeviceReportInfo *")]
        public GameInputRawDeviceReportInfo* inputReport;

        [NativeTypeName("const GameInputRawDeviceReportItemInfo *")]
        public GameInputRawDeviceReportItemInfo* inputReportItem;
    }

    public unsafe partial struct GameInputControllerButtonInfo
    {
        public GameInputKind mappedInputKinds;

        public GameInputLabel label;

        [NativeTypeName("uint16_t")]
        public ushort legacyDInputIndex;

        [NativeTypeName("uint16_t")]
        public ushort legacyHidIndex;

        [NativeTypeName("uint32_t")]
        public uint rawReportIndex;

        [NativeTypeName("const GameInputRawDeviceReportInfo *")]
        public GameInputRawDeviceReportInfo* inputReport;

        [NativeTypeName("const GameInputRawDeviceReportItemInfo *")]
        public GameInputRawDeviceReportItemInfo* inputReportItem;
    }

    public unsafe partial struct GameInputControllerSwitchInfo
    {
        public GameInputKind mappedInputKinds;

        public GameInputLabel label;

        [NativeTypeName("GameInputLabel[9]")]
        public _positionLabels_e__FixedBuffer positionLabels;

        public GameInputSwitchKind kind;

        [NativeTypeName("uint16_t")]
        public ushort legacyDInputIndex;

        [NativeTypeName("uint16_t")]
        public ushort legacyHidIndex;

        [NativeTypeName("uint32_t")]
        public uint rawReportIndex;

        [NativeTypeName("const GameInputRawDeviceReportInfo *")]
        public GameInputRawDeviceReportInfo* inputReport;

        [NativeTypeName("const GameInputRawDeviceReportItemInfo *")]
        public GameInputRawDeviceReportItemInfo* inputReportItem;

        public partial struct _positionLabels_e__FixedBuffer
        {
            public GameInputLabel e0;
            public GameInputLabel e1;
            public GameInputLabel e2;
            public GameInputLabel e3;
            public GameInputLabel e4;
            public GameInputLabel e5;
            public GameInputLabel e6;
            public GameInputLabel e7;
            public GameInputLabel e8;
#if NETSTANDARD2_0

            // dev-note: if you're using Net-Standard 2.0 you can enjoy the slower code-paths until you upgrade/update to Net 6.0 or higher 

            public unsafe GameInputLabel this[int index]
            {
                get
                {
                    if ((uint)index > 8)
                        throw new ArgumentOutOfRangeException(nameof(index));

                    return index switch
                    {
                        0 => e0,
                        1 => e1,
                        2 => e2,
                        3 => e3,
                        4 => e4,
                        5 => e5,
                        6 => e6,
                        7 => e7,
                        8 => e8,
                        _ => throw new ArgumentOutOfRangeException(nameof(index)),
                    };
                }
                set
                {
                    if ((uint)index > 8)
                        throw new ArgumentOutOfRangeException(nameof(index));

                    switch (index)
                    {
                    case 0:
                            e0 = value;
                            break;
                            case 1:
                            e1 = value;
                            break;
                        case 2:
                            e2 = value;
                            break;
                        case 3:
                            e3 = value;
                            break;
                        case 4:
                            e4 = value;
                            break;
                        case 5:
                            e5 = value;
                            break;
                        case 6:
                            e6 = value;
                            break;
                        case 7:
                            e7 = value;
                            break;
                        case 8:
                            e8 = value;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(index));
                    }
                }
            }

#elif NET6_0_OR_GREATER
            public GameInputLabel this[int index]
            {
                get
                {
                    return AsSpan()[index];
                }
                set
                {
                    AsSpan()[index] = value;
                }
            }
            public Span<GameInputLabel> AsSpan() => MemoryMarshal.CreateSpan(ref e0, 9);
#endif
        }
    }

    public unsafe partial struct GameInputKeyboardInfo
    {
        public GameInputKeyboardKind kind;

        public GameInputKeyboardLayout layout;

        [NativeTypeName("uint32_t")]
        public uint keyCount;

        [NativeTypeName("uint32_t")]
        public uint functionKeyCount;

        [NativeTypeName("uint32_t")]
        public uint maxSimultaneousKeys;

        [NativeTypeName("uint32_t")]
        public uint platformType;

        [NativeTypeName("uint32_t")]
        public uint platformSubtype;

        [NativeTypeName("const GameInputString *")]
        public GameInputString* nativeLanguage;
    }

    public partial struct GameInputMouseInfo
    {
        public GameInputMouseButtons supportedButtons;

        [NativeTypeName("uint32_t")]
        public uint sampleRate;

        [NativeTypeName("uint32_t")]
        public uint sensorDpi;

        [NativeTypeName("bool")]
        public byte hasWheelX;

        [NativeTypeName("bool")]
        public byte hasWheelY;
    }

    public partial struct GameInputTouchSensorInfo
    {
        public GameInputKind mappedInputKinds;

        public GameInputLabel label;

        public GameInputLocation location;

        [NativeTypeName("uint32_t")]
        public uint locationId;

        [NativeTypeName("uint64_t")]
        public ulong resolutionX;

        [NativeTypeName("uint64_t")]
        public ulong resolutionY;

        public GameInputTouchShape shape;

        public float aspectRatio;

        public float orientation;

        public float physicalWidth;

        public float physicalHeight;

        public float maxPressure;

        public float maxProximity;

        [NativeTypeName("uint32_t")]
        public uint maxTouchPoints;
    }

    public partial struct GameInputMotionInfo
    {
        public float maxAcceleration;

        public float maxAngularVelocity;

        public float maxMagneticFieldStrength;
    }

    public partial struct GameInputArcadeStickInfo
    {
        public GameInputLabel menuButtonLabel;

        public GameInputLabel viewButtonLabel;

        public GameInputLabel stickUpLabel;

        public GameInputLabel stickDownLabel;

        public GameInputLabel stickLeftLabel;

        public GameInputLabel stickRightLabel;

        public GameInputLabel actionButton1Label;

        public GameInputLabel actionButton2Label;

        public GameInputLabel actionButton3Label;

        public GameInputLabel actionButton4Label;

        public GameInputLabel actionButton5Label;

        public GameInputLabel actionButton6Label;

        public GameInputLabel specialButton1Label;

        public GameInputLabel specialButton2Label;
    }

    public partial struct GameInputFlightStickInfo
    {
        public GameInputLabel menuButtonLabel;

        public GameInputLabel viewButtonLabel;

        public GameInputLabel firePrimaryButtonLabel;

        public GameInputLabel fireSecondaryButtonLabel;

        public GameInputSwitchKind hatSwitchKind;
    }

    public partial struct GameInputGamepadInfo
    {
        public GameInputLabel menuButtonLabel;

        public GameInputLabel viewButtonLabel;

        public GameInputLabel aButtonLabel;

        public GameInputLabel bButtonLabel;

        public GameInputLabel xButtonLabel;

        public GameInputLabel yButtonLabel;

        public GameInputLabel dpadUpLabel;

        public GameInputLabel dpadDownLabel;

        public GameInputLabel dpadLeftLabel;

        public GameInputLabel dpadRightLabel;

        public GameInputLabel leftShoulderButtonLabel;

        public GameInputLabel rightShoulderButtonLabel;

        public GameInputLabel leftThumbstickButtonLabel;

        public GameInputLabel rightThumbstickButtonLabel;
    }

    public partial struct GameInputRacingWheelInfo
    {
        public GameInputLabel menuButtonLabel;

        public GameInputLabel viewButtonLabel;

        public GameInputLabel previousGearButtonLabel;

        public GameInputLabel nextGearButtonLabel;

        public GameInputLabel dpadUpLabel;

        public GameInputLabel dpadDownLabel;

        public GameInputLabel dpadLeftLabel;

        public GameInputLabel dpadRightLabel;

        [NativeTypeName("bool")]
        public byte hasClutch;

        [NativeTypeName("bool")]
        public byte hasHandbrake;

        [NativeTypeName("bool")]
        public byte hasPatternShifter;

        [NativeTypeName("int32_t")]
        public int minPatternShifterGear;

        [NativeTypeName("int32_t")]
        public int maxPatternShifterGear;

        public float maxWheelAngle;
    }

    public partial struct GameInputUiNavigationInfo
    {
        public GameInputLabel menuButtonLabel;

        public GameInputLabel viewButtonLabel;

        public GameInputLabel acceptButtonLabel;

        public GameInputLabel cancelButtonLabel;

        public GameInputLabel upButtonLabel;

        public GameInputLabel downButtonLabel;

        public GameInputLabel leftButtonLabel;

        public GameInputLabel rightButtonLabel;

        public GameInputLabel contextButton1Label;

        public GameInputLabel contextButton2Label;

        public GameInputLabel contextButton3Label;

        public GameInputLabel contextButton4Label;

        public GameInputLabel pageUpButtonLabel;

        public GameInputLabel pageDownButtonLabel;

        public GameInputLabel pageLeftButtonLabel;

        public GameInputLabel pageRightButtonLabel;

        public GameInputLabel scrollUpButtonLabel;

        public GameInputLabel scrollDownButtonLabel;

        public GameInputLabel scrollLeftButtonLabel;

        public GameInputLabel scrollRightButtonLabel;

        public GameInputLabel guideButtonLabel;
    }

    public partial struct GameInputForceFeedbackMotorInfo
    {
        public GameInputFeedbackAxes supportedAxes;

        public GameInputLocation location;

        [NativeTypeName("uint32_t")]
        public uint locationId;

        [NativeTypeName("uint32_t")]
        public uint maxSimultaneousEffects;

        [NativeTypeName("bool")]
        public byte isConstantEffectSupported;

        [NativeTypeName("bool")]
        public byte isRampEffectSupported;

        [NativeTypeName("bool")]
        public byte isSineWaveEffectSupported;

        [NativeTypeName("bool")]
        public byte isSquareWaveEffectSupported;

        [NativeTypeName("bool")]
        public byte isTriangleWaveEffectSupported;

        [NativeTypeName("bool")]
        public byte isSawtoothUpWaveEffectSupported;

        [NativeTypeName("bool")]
        public byte isSawtoothDownWaveEffectSupported;

        [NativeTypeName("bool")]
        public byte isSpringEffectSupported;

        [NativeTypeName("bool")]
        public byte isFrictionEffectSupported;

        [NativeTypeName("bool")]
        public byte isDamperEffectSupported;

        [NativeTypeName("bool")]
        public byte isInertiaEffectSupported;
    }

    public partial struct GameInputHapticWaveformInfo
    {
        public GameInputUsage usage;

        [NativeTypeName("bool")]
        public byte isDurationSupported;

        [NativeTypeName("bool")]
        public byte isIntensitySupported;

        [NativeTypeName("bool")]
        public byte isRepeatSupported;

        [NativeTypeName("bool")]
        public byte isRepeatDelaySupported;

        [NativeTypeName("uint64_t")]
        public ulong defaultDuration;
    }

    public unsafe partial struct GameInputHapticFeedbackMotorInfo
    {
        public GameInputRumbleMotors mappedRumbleMotors;

        public GameInputLocation location;

        [NativeTypeName("uint32_t")]
        public uint locationId;

        [NativeTypeName("uint32_t")]
        public uint waveformCount;

        [NativeTypeName("const GameInputHapticWaveformInfo *")]
        public GameInputHapticWaveformInfo* waveformInfo;
    }

    public unsafe partial struct GameInputDeviceInfo
    {
        [NativeTypeName("uint32_t")]
        public uint infoSize;

        [NativeTypeName("uint16_t")]
        public ushort vendorId;

        [NativeTypeName("uint16_t")]
        public ushort productId;

        [NativeTypeName("uint16_t")]
        public ushort revisionNumber;

        [NativeTypeName("uint8_t")]
        public byte interfaceNumber;

        [NativeTypeName("uint8_t")]
        public byte collectionNumber;

        public GameInputUsage usage;

        public GameInputVersion hardwareVersion;

        public GameInputVersion firmwareVersion;

        public APP_LOCAL_DEVICE_ID deviceId;

        public APP_LOCAL_DEVICE_ID deviceRootId;

        public GameInputDeviceFamily deviceFamily;

        public GameInputDeviceCapabilities capabilities;

        public GameInputKind supportedInput;

        public GameInputRumbleMotors supportedRumbleMotors;

        [NativeTypeName("uint32_t")]
        public uint inputReportCount;

        [NativeTypeName("uint32_t")]
        public uint outputReportCount;

        [NativeTypeName("uint32_t")]
        public uint featureReportCount;

        [NativeTypeName("uint32_t")]
        public uint controllerAxisCount;

        [NativeTypeName("uint32_t")]
        public uint controllerButtonCount;

        [NativeTypeName("uint32_t")]
        public uint controllerSwitchCount;

        [NativeTypeName("uint32_t")]
        public uint touchPointCount;

        [NativeTypeName("uint32_t")]
        public uint touchSensorCount;

        [NativeTypeName("uint32_t")]
        public uint forceFeedbackMotorCount;

        [NativeTypeName("uint32_t")]
        public uint hapticFeedbackMotorCount;

        [NativeTypeName("uint32_t")]
        public uint deviceStringCount;

        [NativeTypeName("uint32_t")]
        public uint deviceDescriptorSize;

        [NativeTypeName("const GameInputRawDeviceReportInfo *")]
        public GameInputRawDeviceReportInfo* inputReportInfo;

        [NativeTypeName("const GameInputRawDeviceReportInfo *")]
        public GameInputRawDeviceReportInfo* outputReportInfo;

        [NativeTypeName("const GameInputRawDeviceReportInfo *")]
        public GameInputRawDeviceReportInfo* featureReportInfo;

        [NativeTypeName("const GameInputControllerAxisInfo *")]
        public GameInputControllerAxisInfo* controllerAxisInfo;

        [NativeTypeName("const GameInputControllerButtonInfo *")]
        public GameInputControllerButtonInfo* controllerButtonInfo;

        [NativeTypeName("const GameInputControllerSwitchInfo *")]
        public GameInputControllerSwitchInfo* controllerSwitchInfo;

        [NativeTypeName("const GameInputKeyboardInfo *")]
        public GameInputKeyboardInfo* keyboardInfo;

        [NativeTypeName("const GameInputMouseInfo *")]
        public GameInputMouseInfo* mouseInfo;

        [NativeTypeName("const GameInputTouchSensorInfo *")]
        public GameInputTouchSensorInfo* touchSensorInfo;

        [NativeTypeName("const GameInputMotionInfo *")]
        public GameInputMotionInfo* motionInfo;

        [NativeTypeName("const GameInputArcadeStickInfo *")]
        public GameInputArcadeStickInfo* arcadeStickInfo;

        [NativeTypeName("const GameInputFlightStickInfo *")]
        public GameInputFlightStickInfo* flightStickInfo;

        [NativeTypeName("const GameInputGamepadInfo *")]
        public GameInputGamepadInfo* gamepadInfo;

        [NativeTypeName("const GameInputRacingWheelInfo *")]
        public GameInputRacingWheelInfo* racingWheelInfo;

        [NativeTypeName("const GameInputUiNavigationInfo *")]
        public GameInputUiNavigationInfo* uiNavigationInfo;

        [NativeTypeName("const GameInputForceFeedbackMotorInfo *")]
        public GameInputForceFeedbackMotorInfo* forceFeedbackMotorInfo;

        [NativeTypeName("const GameInputHapticFeedbackMotorInfo *")]
        public GameInputHapticFeedbackMotorInfo* hapticFeedbackMotorInfo;

        [NativeTypeName("const GameInputString *")]
        public GameInputString* displayName;

        [NativeTypeName("const GameInputString *")]
        public GameInputString* deviceStrings;

        [NativeTypeName("const void *")]
        public void* deviceDescriptorData;
    }

    public partial struct GameInputForceFeedbackEnvelope
    {
        [NativeTypeName("uint64_t")]
        public ulong attackDuration;

        [NativeTypeName("uint64_t")]
        public ulong sustainDuration;

        [NativeTypeName("uint64_t")]
        public ulong releaseDuration;

        public float attackGain;

        public float sustainGain;

        public float releaseGain;

        [NativeTypeName("uint32_t")]
        public uint playCount;

        [NativeTypeName("uint64_t")]
        public ulong repeatDelay;
    }

    public partial struct GameInputForceFeedbackMagnitude
    {
        public float linearX;

        public float linearY;

        public float linearZ;

        public float angularX;

        public float angularY;

        public float angularZ;

        public float normal;
    }

    public partial struct GameInputForceFeedbackConditionParams
    {
        public GameInputForceFeedbackMagnitude magnitude;

        public float positiveCoefficient;

        public float negativeCoefficient;

        public float maxPositiveMagnitude;

        public float maxNegativeMagnitude;

        public float deadZone;

        public float bias;
    }

    public partial struct GameInputForceFeedbackConstantParams
    {
        public GameInputForceFeedbackEnvelope envelope;

        public GameInputForceFeedbackMagnitude magnitude;
    }

    public partial struct GameInputForceFeedbackPeriodicParams
    {
        public GameInputForceFeedbackEnvelope envelope;

        public GameInputForceFeedbackMagnitude magnitude;

        public float frequency;

        public float phase;

        public float bias;
    }

    public partial struct GameInputForceFeedbackRampParams
    {
        public GameInputForceFeedbackEnvelope envelope;

        public GameInputForceFeedbackMagnitude startMagnitude;

        public GameInputForceFeedbackMagnitude endMagnitude;
    }

    public partial struct GameInputForceFeedbackParams
    {
        public GameInputForceFeedbackEffectKind kind;

        [NativeTypeName("union (anonymous union at C:/Program Files (x86)/Microsoft GDK/220601/GRDK/GameKit/Include/GameInput.h:1261:5)")]
        public _data_e__Union data;

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _data_e__Union
        {
            [FieldOffset(0)]
            public GameInputForceFeedbackConstantParams constant;

            [FieldOffset(0)]
            public GameInputForceFeedbackRampParams ramp;

            [FieldOffset(0)]
            public GameInputForceFeedbackPeriodicParams sineWave;

            [FieldOffset(0)]
            public GameInputForceFeedbackPeriodicParams squareWave;

            [FieldOffset(0)]
            public GameInputForceFeedbackPeriodicParams triangleWave;

            [FieldOffset(0)]
            public GameInputForceFeedbackPeriodicParams sawtoothUpWave;

            [FieldOffset(0)]
            public GameInputForceFeedbackPeriodicParams sawtoothDownWave;

            [FieldOffset(0)]
            public GameInputForceFeedbackConditionParams spring;

            [FieldOffset(0)]
            public GameInputForceFeedbackConditionParams friction;

            [FieldOffset(0)]
            public GameInputForceFeedbackConditionParams damper;

            [FieldOffset(0)]
            public GameInputForceFeedbackConditionParams inertia;
        }
    }

    public partial struct GameInputHapticFeedbackParams
    {
        [NativeTypeName("uint32_t")]
        public uint waveformIndex;

        [NativeTypeName("uint64_t")]
        public ulong duration;

        public float intensity;

        [NativeTypeName("uint32_t")]
        public uint playCount;

        [NativeTypeName("uint64_t")]
        public ulong repeatDelay;
    }

    public partial struct GameInputRumbleParams
    {
        public float lowFrequency;

        public float highFrequency;

        public float leftTrigger;

        public float rightTrigger;
    }

    [Guid("11BE2A7E-4254-445A-9C09-FFC40F006918")]
    [NativeTypeName("struct IGameInput : TerraFX.Interop.Windows.IUnknown")]
    public unsafe partial struct IGameInput
    {
        public void** lpVtbl;

        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInput*, Guid*, void**, int>)(lpVtbl[0]))((IGameInput*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<IGameInput*, uint>)(lpVtbl[1]))((IGameInput*)Unsafe.AsPointer(ref this));
        }

        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<IGameInput*, uint>)(lpVtbl[2]))((IGameInput*)Unsafe.AsPointer(ref this));
        }

        [return: NativeTypeName("uint64_t")]
        public ulong GetCurrentTimestamp()
        {
            return ((delegate* unmanaged[Stdcall]<IGameInput*, ulong>)(lpVtbl[3]))((IGameInput*)Unsafe.AsPointer(ref this));
        }

        [return: NativeTypeName("HRESULT")]
        public int GetCurrentReading(GameInputKind inputKind, IGameInputDevice* device, IGameInputReading** reading)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInput*, GameInputKind, IGameInputDevice*, IGameInputReading**, int>)(lpVtbl[4]))((IGameInput*)Unsafe.AsPointer(ref this), inputKind, device, reading);
        }

        [return: NativeTypeName("HRESULT")]
        public int GetNextReading(IGameInputReading* referenceReading, GameInputKind inputKind, IGameInputDevice* device, IGameInputReading** reading)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInput*, IGameInputReading*, GameInputKind, IGameInputDevice*, IGameInputReading**, int>)(lpVtbl[5]))((IGameInput*)Unsafe.AsPointer(ref this), referenceReading, inputKind, device, reading);
        }

        [return: NativeTypeName("HRESULT")]
        public int GetPreviousReading(IGameInputReading* referenceReading, GameInputKind inputKind, IGameInputDevice* device, IGameInputReading** reading)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInput*, IGameInputReading*, GameInputKind, IGameInputDevice*, IGameInputReading**, int>)(lpVtbl[6]))((IGameInput*)Unsafe.AsPointer(ref this), referenceReading, inputKind, device, reading);
        }

        [return: NativeTypeName("HRESULT")]
        public int GetTemporalReading([NativeTypeName("uint64_t")] ulong timestamp, IGameInputDevice* device, IGameInputReading** reading)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInput*, ulong, IGameInputDevice*, IGameInputReading**, int>)(lpVtbl[7]))((IGameInput*)Unsafe.AsPointer(ref this), timestamp, device, reading);
        }

        [return: NativeTypeName("HRESULT")]
        public int RegisterReadingCallback(IGameInputDevice* device, GameInputKind inputKind, float analogThreshold, void* context, [NativeTypeName("GameInputReadingCallback")] delegate* unmanaged[Stdcall]<ulong, void*, IGameInputReading*, byte, void> callbackFunc, [NativeTypeName("GameInputCallbackToken *")] ulong* callbackToken)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInput*, IGameInputDevice*, GameInputKind, float, void*, delegate* unmanaged[Stdcall]<ulong, void*, IGameInputReading*, byte, void>, ulong*, int>)(lpVtbl[8]))((IGameInput*)Unsafe.AsPointer(ref this), device, inputKind, analogThreshold, context, callbackFunc, callbackToken);
        }

        [return: NativeTypeName("HRESULT")]
        public int RegisterDeviceCallback(IGameInputDevice* device, GameInputKind inputKind, GameInputDeviceStatus statusFilter, GameInputEnumerationKind enumerationKind, void* context, [NativeTypeName("GameInputDeviceCallback")] delegate* unmanaged[Stdcall]<ulong, void*, IGameInputDevice*, ulong, GameInputDeviceStatus, GameInputDeviceStatus, void> callbackFunc, [NativeTypeName("GameInputCallbackToken *")] ulong* callbackToken)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInput*, IGameInputDevice*, GameInputKind, GameInputDeviceStatus, GameInputEnumerationKind, void*, delegate* unmanaged[Stdcall]<ulong, void*, IGameInputDevice*, ulong, GameInputDeviceStatus, GameInputDeviceStatus, void>, ulong*, int>)(lpVtbl[9]))((IGameInput*)Unsafe.AsPointer(ref this), device, inputKind, statusFilter, enumerationKind, context, callbackFunc, callbackToken);
        }

        [return: NativeTypeName("HRESULT")]
        public int RegisterGuideButtonCallback(IGameInputDevice* device, void* context, [NativeTypeName("GameInputGuideButtonCallback")] delegate* unmanaged[Stdcall]<ulong, void*, IGameInputDevice*, ulong, byte, void> callbackFunc, [NativeTypeName("GameInputCallbackToken *")] ulong* callbackToken)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInput*, IGameInputDevice*, void*, delegate* unmanaged[Stdcall]<ulong, void*, IGameInputDevice*, ulong, byte, void>, ulong*, int>)(lpVtbl[10]))((IGameInput*)Unsafe.AsPointer(ref this), device, context, callbackFunc, callbackToken);
        }

        [return: NativeTypeName("HRESULT")]
        public int RegisterKeyboardLayoutCallback(IGameInputDevice* device, void* context, [NativeTypeName("GameInputKeyboardLayoutCallback")] delegate* unmanaged[Stdcall]<ulong, void*, IGameInputDevice*, ulong, GameInputKeyboardLayout, GameInputKeyboardLayout, void> callbackFunc, [NativeTypeName("GameInputCallbackToken *")] ulong* callbackToken)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInput*, IGameInputDevice*, void*, delegate* unmanaged[Stdcall]<ulong, void*, IGameInputDevice*, ulong, GameInputKeyboardLayout, GameInputKeyboardLayout, void>, ulong*, int>)(lpVtbl[11]))((IGameInput*)Unsafe.AsPointer(ref this), device, context, callbackFunc, callbackToken);
        }

        public void StopCallback([NativeTypeName("GameInputCallbackToken")] ulong callbackToken)
        {
            ((delegate* unmanaged[Stdcall]<IGameInput*, ulong, void>)(lpVtbl[12]))((IGameInput*)Unsafe.AsPointer(ref this), callbackToken);
        }

        public bool UnregisterCallback([NativeTypeName("GameInputCallbackToken")] ulong callbackToken, [NativeTypeName("uint64_t")] ulong timeoutInMicroseconds)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInput*, ulong, ulong, byte>)(lpVtbl[13]))((IGameInput*)Unsafe.AsPointer(ref this), callbackToken, timeoutInMicroseconds) != 0;
        }

        [return: NativeTypeName("HRESULT")]
        public int CreateDispatcher(IGameInputDispatcher** dispatcher)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInput*, IGameInputDispatcher**, int>)(lpVtbl[14]))((IGameInput*)Unsafe.AsPointer(ref this), dispatcher);
        }

        [return: NativeTypeName("HRESULT")]
        public int CreateAggregateDevice(GameInputKind inputKind, IGameInputDevice** device)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInput*, GameInputKind, IGameInputDevice**, int>)(lpVtbl[15]))((IGameInput*)Unsafe.AsPointer(ref this), inputKind, device);
        }

        [return: NativeTypeName("HRESULT")]
        public int FindDeviceFromId([NativeTypeName("const APP_LOCAL_DEVICE_ID *")] APP_LOCAL_DEVICE_ID* value, IGameInputDevice** device)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInput*, APP_LOCAL_DEVICE_ID*, IGameInputDevice**, int>)(lpVtbl[16]))((IGameInput*)Unsafe.AsPointer(ref this), value, device);
        }

        /// <summary>
        /// !! That void* is actually an IUnknown* !!
        /// </summary>
        /// <param name="value"></param>
        /// <param name="device"></param>
        /// <returns></returns>
        [return: NativeTypeName("HRESULT")]
        public int FindDeviceFromObject(void* value, IGameInputDevice** device)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInput*, void*, IGameInputDevice**, int>)(lpVtbl[17]))((IGameInput*)Unsafe.AsPointer(ref this), value, device);
        }

        [return: NativeTypeName("HRESULT")]
        public int FindDeviceFromPlatformHandle([NativeTypeName("HANDLE")] void* value, IGameInputDevice** device)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInput*, void*, IGameInputDevice**, int>)(lpVtbl[18]))((IGameInput*)Unsafe.AsPointer(ref this), value, device);
        }

        [return: NativeTypeName("HRESULT")]
        public int FindDeviceFromPlatformString([NativeTypeName("LPCWSTR")] ushort* value, IGameInputDevice** device)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInput*, ushort*, IGameInputDevice**, int>)(lpVtbl[19]))((IGameInput*)Unsafe.AsPointer(ref this), value, device);
        }

        [return: NativeTypeName("HRESULT")]
        public int EnableOemDeviceSupport([NativeTypeName("uint16_t")] ushort vendorId, [NativeTypeName("uint16_t")] ushort productId, [NativeTypeName("uint8_t")] byte interfaceNumber, [NativeTypeName("uint8_t")] byte collectionNumber)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInput*, ushort, ushort, byte, byte, int>)(lpVtbl[20]))((IGameInput*)Unsafe.AsPointer(ref this), vendorId, productId, interfaceNumber, collectionNumber);
        }

        public void SetFocusPolicy(GameInputFocusPolicy policy)
        {
            ((delegate* unmanaged[Stdcall]<IGameInput*, GameInputFocusPolicy, void>)(lpVtbl[21]))((IGameInput*)Unsafe.AsPointer(ref this), policy);
        }
    }

    [Guid("2156947A-E1FA-4DE0-A30B-D812931DBD8D")]
    [NativeTypeName("struct IGameInputReading : TerraFX.Interop.Windows.IUnknown")]
    public unsafe partial struct IGameInputReading
    {
        public void** lpVtbl;

        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputReading*, Guid*, void**, int>)(lpVtbl[0]))((IGameInputReading*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputReading*, uint>)(lpVtbl[1]))((IGameInputReading*)Unsafe.AsPointer(ref this));
        }

        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputReading*, uint>)(lpVtbl[2]))((IGameInputReading*)Unsafe.AsPointer(ref this));
        }

        public GameInputKind GetInputKind()
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputReading*, GameInputKind>)(lpVtbl[3]))((IGameInputReading*)Unsafe.AsPointer(ref this));
        }

        [return: NativeTypeName("uint64_t")]
        public ulong GetSequenceNumber(GameInputKind inputKind)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputReading*, GameInputKind, ulong>)(lpVtbl[4]))((IGameInputReading*)Unsafe.AsPointer(ref this), inputKind);
        }

        [return: NativeTypeName("uint64_t")]
        public ulong GetTimestamp()
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputReading*, ulong>)(lpVtbl[5]))((IGameInputReading*)Unsafe.AsPointer(ref this));
        }

        public void GetDevice(IGameInputDevice** device)
        {
            ((delegate* unmanaged[Stdcall]<IGameInputReading*, IGameInputDevice**, void>)(lpVtbl[6]))((IGameInputReading*)Unsafe.AsPointer(ref this), device);
        }

        public bool GetRawReport(IGameInputRawDeviceReport** report)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputReading*, IGameInputRawDeviceReport**, byte>)(lpVtbl[7]))((IGameInputReading*)Unsafe.AsPointer(ref this), report) != 0;
        }

        [return: NativeTypeName("uint32_t")]
        public uint GetControllerAxisCount()
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputReading*, uint>)(lpVtbl[8]))((IGameInputReading*)Unsafe.AsPointer(ref this));
        }

        [return: NativeTypeName("uint32_t")]
        public uint GetControllerAxisState([NativeTypeName("uint32_t")] uint stateArrayCount, float* stateArray)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputReading*, uint, float*, uint>)(lpVtbl[9]))((IGameInputReading*)Unsafe.AsPointer(ref this), stateArrayCount, stateArray);
        }

        [return: NativeTypeName("uint32_t")]
        public uint GetControllerButtonCount()
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputReading*, uint>)(lpVtbl[10]))((IGameInputReading*)Unsafe.AsPointer(ref this));
        }

        [return: NativeTypeName("uint32_t")]
        public uint GetControllerButtonState([NativeTypeName("uint32_t")] uint stateArrayCount, bool* stateArray)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputReading*, uint, bool*, uint>)(lpVtbl[11]))((IGameInputReading*)Unsafe.AsPointer(ref this), stateArrayCount, stateArray);
        }

        [return: NativeTypeName("uint32_t")]
        public uint GetControllerSwitchCount()
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputReading*, uint>)(lpVtbl[12]))((IGameInputReading*)Unsafe.AsPointer(ref this));
        }

        [return: NativeTypeName("uint32_t")]
        public uint GetControllerSwitchState([NativeTypeName("uint32_t")] uint stateArrayCount, GameInputSwitchPosition* stateArray)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputReading*, uint, GameInputSwitchPosition*, uint>)(lpVtbl[13]))((IGameInputReading*)Unsafe.AsPointer(ref this), stateArrayCount, stateArray);
        }

        [return: NativeTypeName("uint32_t")]
        public uint GetKeyCount()
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputReading*, uint>)(lpVtbl[14]))((IGameInputReading*)Unsafe.AsPointer(ref this));
        }

        [return: NativeTypeName("uint32_t")]
        public uint GetKeyState([NativeTypeName("uint32_t")] uint stateArrayCount, GameInputKeyState* stateArray)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputReading*, uint, GameInputKeyState*, uint>)(lpVtbl[15]))((IGameInputReading*)Unsafe.AsPointer(ref this), stateArrayCount, stateArray);
        }

        public bool GetMouseState(GameInputMouseState* state)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputReading*, GameInputMouseState*, byte>)(lpVtbl[16]))((IGameInputReading*)Unsafe.AsPointer(ref this), state) != 0;
        }

        [return: NativeTypeName("uint32_t")]
        public uint GetTouchCount()
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputReading*, uint>)(lpVtbl[17]))((IGameInputReading*)Unsafe.AsPointer(ref this));
        }

        [return: NativeTypeName("uint32_t")]
        public uint GetTouchState([NativeTypeName("uint32_t")] uint stateArrayCount, GameInputTouchState* stateArray)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputReading*, uint, GameInputTouchState*, uint>)(lpVtbl[18]))((IGameInputReading*)Unsafe.AsPointer(ref this), stateArrayCount, stateArray);
        }

        public bool GetMotionState(GameInputMotionState* state)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputReading*, GameInputMotionState*, byte>)(lpVtbl[19]))((IGameInputReading*)Unsafe.AsPointer(ref this), state) != 0;
        }

        public bool GetArcadeStickState(GameInputArcadeStickState* state)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputReading*, GameInputArcadeStickState*, byte>)(lpVtbl[20]))((IGameInputReading*)Unsafe.AsPointer(ref this), state) != 0;
        }

        public bool GetFlightStickState(GameInputFlightStickState* state)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputReading*, GameInputFlightStickState*, byte>)(lpVtbl[21]))((IGameInputReading*)Unsafe.AsPointer(ref this), state) != 0;
        }

        public bool GetGamepadState(GameInputGamepadState* state)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputReading*, GameInputGamepadState*, byte>)(lpVtbl[22]))((IGameInputReading*)Unsafe.AsPointer(ref this), state) != 0;
        }

        public bool GetRacingWheelState(GameInputRacingWheelState* state)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputReading*, GameInputRacingWheelState*, byte>)(lpVtbl[23]))((IGameInputReading*)Unsafe.AsPointer(ref this), state) != 0;
        }

        public bool GetUiNavigationState(GameInputUiNavigationState* state)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputReading*, GameInputUiNavigationState*, byte>)(lpVtbl[24]))((IGameInputReading*)Unsafe.AsPointer(ref this), state) != 0;
        }
    }

    [Guid("31DD86FB-4C1B-408A-868F-439B3CD47125")]
    [NativeTypeName("struct IGameInputDevice : TerraFX.Interop.Windows.IUnknown")]
    public unsafe partial struct IGameInputDevice
    {
        public void** lpVtbl;

        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputDevice*, Guid*, void**, int>)(lpVtbl[0]))((IGameInputDevice*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputDevice*, uint>)(lpVtbl[1]))((IGameInputDevice*)Unsafe.AsPointer(ref this));
        }

        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputDevice*, uint>)(lpVtbl[2]))((IGameInputDevice*)Unsafe.AsPointer(ref this));
        }

        [return: NativeTypeName("const GameInputDeviceInfo *")]
        public GameInputDeviceInfo* GetDeviceInfo()
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputDevice*, GameInputDeviceInfo*>)(lpVtbl[3]))((IGameInputDevice*)Unsafe.AsPointer(ref this));
        }

        public GameInputDeviceStatus GetDeviceStatus()
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputDevice*, GameInputDeviceStatus>)(lpVtbl[4]))((IGameInputDevice*)Unsafe.AsPointer(ref this));
        }

        public void GetBatteryState(GameInputBatteryState* state)
        {
            ((delegate* unmanaged[Stdcall]<IGameInputDevice*, GameInputBatteryState*, void>)(lpVtbl[5]))((IGameInputDevice*)Unsafe.AsPointer(ref this), state);
        }

        [return: NativeTypeName("HRESULT")]
        public int CreateForceFeedbackEffect([NativeTypeName("uint32_t")] uint motorIndex, [NativeTypeName("const GameInputForceFeedbackParams *")] GameInputForceFeedbackParams* @params, IGameInputForceFeedbackEffect** effect)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputDevice*, uint, GameInputForceFeedbackParams*, IGameInputForceFeedbackEffect**, int>)(lpVtbl[6]))((IGameInputDevice*)Unsafe.AsPointer(ref this), motorIndex, @params, effect);
        }

        public bool IsForceFeedbackMotorPoweredOn([NativeTypeName("uint32_t")] uint motorIndex)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputDevice*, uint, byte>)(lpVtbl[7]))((IGameInputDevice*)Unsafe.AsPointer(ref this), motorIndex) != 0;
        }

        public void SetForceFeedbackMotorGain([NativeTypeName("uint32_t")] uint motorIndex, float masterGain)
        {
            ((delegate* unmanaged[Stdcall]<IGameInputDevice*, uint, float, void>)(lpVtbl[8]))((IGameInputDevice*)Unsafe.AsPointer(ref this), motorIndex, masterGain);
        }

        [return: NativeTypeName("HRESULT")]
        public int SetHapticMotorState([NativeTypeName("uint32_t")] uint motorIndex, [NativeTypeName("const GameInputHapticFeedbackParams *")] GameInputHapticFeedbackParams* @params)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputDevice*, uint, GameInputHapticFeedbackParams*, int>)(lpVtbl[9]))((IGameInputDevice*)Unsafe.AsPointer(ref this), motorIndex, @params);
        }

        public void SetRumbleState([NativeTypeName("const GameInputRumbleParams *")] GameInputRumbleParams* @params)
        {
            ((delegate* unmanaged[Stdcall]<IGameInputDevice*, GameInputRumbleParams*, void>)(lpVtbl[10]))((IGameInputDevice*)Unsafe.AsPointer(ref this), @params);
        }

        public void SetInputSynchronizationState([NativeTypeName("bool")] byte enabled)
        {
            ((delegate* unmanaged[Stdcall]<IGameInputDevice*, byte, void>)(lpVtbl[11]))((IGameInputDevice*)Unsafe.AsPointer(ref this), enabled);
        }

        public void SendInputSynchronizationHint()
        {
            ((delegate* unmanaged[Stdcall]<IGameInputDevice*, void>)(lpVtbl[12]))((IGameInputDevice*)Unsafe.AsPointer(ref this));
        }

        public void PowerOff()
        {
            ((delegate* unmanaged[Stdcall]<IGameInputDevice*, void>)(lpVtbl[13]))((IGameInputDevice*)Unsafe.AsPointer(ref this));
        }

        [return: NativeTypeName("HRESULT")]
        public int CreateRawDeviceReport([NativeTypeName("uint32_t")] uint reportId, GameInputRawDeviceReportKind reportKind, IGameInputRawDeviceReport** report)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputDevice*, uint, GameInputRawDeviceReportKind, IGameInputRawDeviceReport**, int>)(lpVtbl[14]))((IGameInputDevice*)Unsafe.AsPointer(ref this), reportId, reportKind, report);
        }

        [return: NativeTypeName("HRESULT")]
        public int GetRawDeviceFeature([NativeTypeName("uint32_t")] uint reportId, IGameInputRawDeviceReport** report)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputDevice*, uint, IGameInputRawDeviceReport**, int>)(lpVtbl[15]))((IGameInputDevice*)Unsafe.AsPointer(ref this), reportId, report);
        }

        [return: NativeTypeName("HRESULT")]
        public int SetRawDeviceFeature(IGameInputRawDeviceReport* report)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputDevice*, IGameInputRawDeviceReport*, int>)(lpVtbl[16]))((IGameInputDevice*)Unsafe.AsPointer(ref this), report);
        }

        [return: NativeTypeName("HRESULT")]
        public int SendRawDeviceOutput(IGameInputRawDeviceReport* report)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputDevice*, IGameInputRawDeviceReport*, int>)(lpVtbl[17]))((IGameInputDevice*)Unsafe.AsPointer(ref this), report);
        }

        [return: NativeTypeName("HRESULT")]
        public int ExecuteRawDeviceIoControl([NativeTypeName("uint32_t")] uint controlCode, [NativeTypeName("size_t")] nuint inputBufferSize, [NativeTypeName("const void *")] void* inputBuffer, [NativeTypeName("size_t")] nuint outputBufferSize, void* outputBuffer, [NativeTypeName("size_t *")] nuint* outputSize)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputDevice*, uint, nuint, void*, nuint, void*, nuint*, int>)(lpVtbl[18]))((IGameInputDevice*)Unsafe.AsPointer(ref this), controlCode, inputBufferSize, inputBuffer, outputBufferSize, outputBuffer, outputSize);
        }

        public bool AcquireExclusiveRawDeviceAccess([NativeTypeName("uint64_t")] ulong timeoutInMicroseconds)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputDevice*, ulong, byte>)(lpVtbl[19]))((IGameInputDevice*)Unsafe.AsPointer(ref this), timeoutInMicroseconds) != 0;
        }

        public void ReleaseExclusiveRawDeviceAccess()
        {
            ((delegate* unmanaged[Stdcall]<IGameInputDevice*, void>)(lpVtbl[20]))((IGameInputDevice*)Unsafe.AsPointer(ref this));
        }
    }

    [Guid("415EED2E-98CB-42C2-8F28-B94601074E31")]
    [NativeTypeName("struct IGameInputDispatcher : TerraFX.Interop.Windows.IUnknown")]
    public unsafe partial struct IGameInputDispatcher
    {
        public void** lpVtbl;

        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputDispatcher*, Guid*, void**, int>)(lpVtbl[0]))((IGameInputDispatcher*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputDispatcher*, uint>)(lpVtbl[1]))((IGameInputDispatcher*)Unsafe.AsPointer(ref this));
        }

        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputDispatcher*, uint>)(lpVtbl[2]))((IGameInputDispatcher*)Unsafe.AsPointer(ref this));
        }

        public bool Dispatch([NativeTypeName("uint64_t")] ulong quotaInMicroseconds)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputDispatcher*, ulong, byte>)(lpVtbl[3]))((IGameInputDispatcher*)Unsafe.AsPointer(ref this), quotaInMicroseconds) != 0;
        }

        [return: NativeTypeName("HRESULT")]
        public int OpenWaitHandle([NativeTypeName("HANDLE *")] void** waitHandle)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputDispatcher*, void**, int>)(lpVtbl[4]))((IGameInputDispatcher*)Unsafe.AsPointer(ref this), waitHandle);
        }
    }

    [Guid("51BDA05E-F742-45D9-B085-9444AE48381D")]
    [NativeTypeName("struct IGameInputForceFeedbackEffect : TerraFX.Interop.Windows.IUnknown")]
    public unsafe partial struct IGameInputForceFeedbackEffect
    {
        public void** lpVtbl;

        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputForceFeedbackEffect*, Guid*, void**, int>)(lpVtbl[0]))((IGameInputForceFeedbackEffect*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputForceFeedbackEffect*, uint>)(lpVtbl[1]))((IGameInputForceFeedbackEffect*)Unsafe.AsPointer(ref this));
        }

        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputForceFeedbackEffect*, uint>)(lpVtbl[2]))((IGameInputForceFeedbackEffect*)Unsafe.AsPointer(ref this));
        }

        public void GetDevice(IGameInputDevice** device)
        {
            ((delegate* unmanaged[Stdcall]<IGameInputForceFeedbackEffect*, IGameInputDevice**, void>)(lpVtbl[3]))((IGameInputForceFeedbackEffect*)Unsafe.AsPointer(ref this), device);
        }

        [return: NativeTypeName("uint32_t")]
        public uint GetMotorIndex()
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputForceFeedbackEffect*, uint>)(lpVtbl[4]))((IGameInputForceFeedbackEffect*)Unsafe.AsPointer(ref this));
        }

        public float GetGain()
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputForceFeedbackEffect*, float>)(lpVtbl[5]))((IGameInputForceFeedbackEffect*)Unsafe.AsPointer(ref this));
        }

        public void SetGain(float gain)
        {
            ((delegate* unmanaged[Stdcall]<IGameInputForceFeedbackEffect*, float, void>)(lpVtbl[6]))((IGameInputForceFeedbackEffect*)Unsafe.AsPointer(ref this), gain);
        }

        public void GetParams(GameInputForceFeedbackParams* @params)
        {
            ((delegate* unmanaged[Stdcall]<IGameInputForceFeedbackEffect*, GameInputForceFeedbackParams*, void>)(lpVtbl[7]))((IGameInputForceFeedbackEffect*)Unsafe.AsPointer(ref this), @params);
        }

        public bool SetParams([NativeTypeName("const GameInputForceFeedbackParams *")] GameInputForceFeedbackParams* @params)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputForceFeedbackEffect*, GameInputForceFeedbackParams*, byte>)(lpVtbl[8]))((IGameInputForceFeedbackEffect*)Unsafe.AsPointer(ref this), @params) != 0;
        }

        public GameInputFeedbackEffectState GetState()
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputForceFeedbackEffect*, GameInputFeedbackEffectState>)(lpVtbl[9]))((IGameInputForceFeedbackEffect*)Unsafe.AsPointer(ref this));
        }

        public void SetState(GameInputFeedbackEffectState state)
        {
            ((delegate* unmanaged[Stdcall]<IGameInputForceFeedbackEffect*, GameInputFeedbackEffectState, void>)(lpVtbl[10]))((IGameInputForceFeedbackEffect*)Unsafe.AsPointer(ref this), state);
        }
    }

    [Guid("61F08CF1-1FFC-40CA-A2B8-E1AB8BC5B6DC")]
    [NativeTypeName("struct IGameInputRawDeviceReport : TerraFX.Interop.Windows.IUnknown")]
    public unsafe partial struct IGameInputRawDeviceReport
    {
        public void** lpVtbl;

        [return: NativeTypeName("HRESULT")]
        public int QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputRawDeviceReport*, Guid*, void**, int>)(lpVtbl[0]))((IGameInputRawDeviceReport*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputRawDeviceReport*, uint>)(lpVtbl[1]))((IGameInputRawDeviceReport*)Unsafe.AsPointer(ref this));
        }

        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputRawDeviceReport*, uint>)(lpVtbl[2]))((IGameInputRawDeviceReport*)Unsafe.AsPointer(ref this));
        }

        public void GetDevice(IGameInputDevice** device)
        {
            ((delegate* unmanaged[Stdcall]<IGameInputRawDeviceReport*, IGameInputDevice**, void>)(lpVtbl[3]))((IGameInputRawDeviceReport*)Unsafe.AsPointer(ref this), device);
        }

        [return: NativeTypeName("const GameInputRawDeviceReportInfo *")]
        public GameInputRawDeviceReportInfo* GetReportInfo()
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputRawDeviceReport*, GameInputRawDeviceReportInfo*>)(lpVtbl[4]))((IGameInputRawDeviceReport*)Unsafe.AsPointer(ref this));
        }

        [return: NativeTypeName("size_t")]
        public nuint GetRawDataSize()
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputRawDeviceReport*, nuint>)(lpVtbl[5]))((IGameInputRawDeviceReport*)Unsafe.AsPointer(ref this));
        }

        [return: NativeTypeName("size_t")]
        public nuint GetRawData([NativeTypeName("size_t")] nuint bufferSize, void* buffer)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputRawDeviceReport*, nuint, void*, nuint>)(lpVtbl[6]))((IGameInputRawDeviceReport*)Unsafe.AsPointer(ref this), bufferSize, buffer);
        }

        public bool SetRawData([NativeTypeName("size_t")] nuint bufferSize, [NativeTypeName("const void *")] void* buffer)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputRawDeviceReport*, nuint, void*, byte>)(lpVtbl[7]))((IGameInputRawDeviceReport*)Unsafe.AsPointer(ref this), bufferSize, buffer) != 0;
        }

        public bool GetItemValue([NativeTypeName("uint32_t")] uint itemIndex, [NativeTypeName("int64_t *")] long* value)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputRawDeviceReport*, uint, long*, byte>)(lpVtbl[8]))((IGameInputRawDeviceReport*)Unsafe.AsPointer(ref this), itemIndex, value) != 0;
        }

        public bool SetItemValue([NativeTypeName("uint32_t")] uint itemIndex, [NativeTypeName("int64_t")] long value)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputRawDeviceReport*, uint, long, byte>)(lpVtbl[9]))((IGameInputRawDeviceReport*)Unsafe.AsPointer(ref this), itemIndex, value) != 0;
        }

        public bool ResetItemValue([NativeTypeName("uint32_t")] uint itemIndex)
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputRawDeviceReport*, uint, byte>)(lpVtbl[10]))((IGameInputRawDeviceReport*)Unsafe.AsPointer(ref this), itemIndex) != 0;
        }

        public bool ResetAllItems()
        {
            return ((delegate* unmanaged[Stdcall]<IGameInputRawDeviceReport*, byte>)(lpVtbl[11]))((IGameInputRawDeviceReport*)Unsafe.AsPointer(ref this)) != 0;
        }
    }

    public static unsafe partial class Methods
    {

        [DllImport("GameInput.dll", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [return: NativeTypeName("HRESULT")]
        public static extern int GameInputCreate(IGameInput** gameInput);

        public static readonly Guid IID_IGameInput = new Guid(0x11BE2A7E, 0x4254, 0x445A, 0x9C, 0x09, 0xFF, 0xC4, 0x0F, 0x00, 0x69, 0x18);

        public static readonly Guid IID_IGameInputReading = new Guid(0x2156947A, 0xE1FA, 0x4DE0, 0xA3, 0x0B, 0xD8, 0x12, 0x93, 0x1D, 0xBD, 0x8D);

        public static readonly Guid IID_IGameInputDevice = new Guid(0x31DD86FB, 0x4C1B, 0x408A, 0x86, 0x8F, 0x43, 0x9B, 0x3C, 0xD4, 0x71, 0x25);

        public static readonly Guid IID_IGameInputDispatcher = new Guid(0x415EED2E, 0x98CB, 0x42C2, 0x8F, 0x28, 0xB9, 0x46, 0x01, 0x07, 0x4E, 0x31);

        public static readonly Guid IID_IGameInputForceFeedbackEffect = new Guid(0x51BDA05E, 0xF742, 0x45D9, 0xB0, 0x85, 0x94, 0x44, 0xAE, 0x48, 0x38, 0x1D);

        public static readonly Guid IID_IGameInputRawDeviceReport = new Guid(0x61F08CF1, 0x1FFC, 0x40CA, 0xA2, 0xB8, 0xE1, 0xAB, 0x8B, 0xC5, 0xB6, 0xDC);
    }

    public readonly unsafe partial struct HRESULT : IComparable, IComparable<HRESULT>, IEquatable<HRESULT>, IFormattable
    {
        public readonly int Value;

        public HRESULT(int value)
        {
            Value = value;
        }

        public bool FAILED => Value < 0;

        public bool SUCCEEDED => Value >= 0;

        public static bool operator ==(HRESULT left, HRESULT right) => left.Value == right.Value;

        public static bool operator !=(HRESULT left, HRESULT right) => left.Value != right.Value;

        public static bool operator <(HRESULT left, HRESULT right) => left.Value < right.Value;

        public static bool operator <=(HRESULT left, HRESULT right) => left.Value <= right.Value;

        public static bool operator >(HRESULT left, HRESULT right) => left.Value > right.Value;

        public static bool operator >=(HRESULT left, HRESULT right) => left.Value >= right.Value;

        public static implicit operator HRESULT(byte value) => new HRESULT(value);

        public static explicit operator byte(HRESULT value) => (byte)(value.Value);

        public static implicit operator HRESULT(short value) => new HRESULT(value);

        public static explicit operator short(HRESULT value) => (short)(value.Value);

        public static implicit operator HRESULT(int value) => new HRESULT(value);

        public static implicit operator int(HRESULT value) => value.Value;

        public static explicit operator HRESULT(long value) => new HRESULT(unchecked((int)(value)));

        public static implicit operator long(HRESULT value) => value.Value;

        public static explicit operator HRESULT(nint value) => new HRESULT(unchecked((int)(value)));

        public static implicit operator nint(HRESULT value) => value.Value;

        public static implicit operator HRESULT(sbyte value) => new HRESULT(value);

        public static explicit operator sbyte(HRESULT value) => (sbyte)(value.Value);

        public static implicit operator HRESULT(ushort value) => new HRESULT(value);

        public static explicit operator ushort(HRESULT value) => (ushort)(value.Value);

        public static explicit operator HRESULT(uint value) => new HRESULT(unchecked((int)(value)));

        public static explicit operator uint(HRESULT value) => (uint)(value.Value);

        public static explicit operator HRESULT(ulong value) => new HRESULT(unchecked((int)(value)));

        public static explicit operator ulong(HRESULT value) => (ulong)(value.Value);

        public static explicit operator HRESULT(nuint value) => new HRESULT(unchecked((int)(value)));

        public static explicit operator nuint(HRESULT value) => (nuint)(value.Value);

        public int CompareTo(object? obj)
        {
            if (obj is HRESULT other)
            {
                return CompareTo(other);
            }

            return (obj is null) ? 1 : throw new ArgumentException("obj is not an instance of HRESULT.");
        }

        public int CompareTo(HRESULT other) => Value.CompareTo(other.Value);

        public override bool Equals(object? obj) => (obj is HRESULT other) && Equals(other);

        public bool Equals(HRESULT other) => Value.Equals(other.Value);

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value.ToString("X8");

        public string ToString(string? format, IFormatProvider? formatProvider) => Value.ToString(format, formatProvider);
    }

    public unsafe partial struct APP_LOCAL_DEVICE_ID
    {
        [NativeTypeName("BYTE[32]")]
        public fixed byte value[32];
    }

#nullable restore
}
