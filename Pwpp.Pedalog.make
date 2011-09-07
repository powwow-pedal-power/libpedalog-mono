

# Warning: This is an automatically generated file, do not edit!

if ENABLE_DEBUG
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;TRACE"
ASSEMBLY = bin/Debug/Pwpp.Pedalog.dll
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug/

PWPP_PEDALOG_DLL_MDB_SOURCE=bin/Debug/Pwpp.Pedalog.dll.mdb
PWPP_PEDALOG_DLL_MDB=$(BUILD_DIR)/Pwpp.Pedalog.dll.mdb

endif

if ENABLE_RELEASE
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+ "-define:TRACE"
ASSEMBLY = bin/Release/Pwpp.Pedalog.dll
ASSEMBLY_MDB = 
COMPILE_TARGET = library
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release/

PWPP_PEDALOG_DLL_MDB=

endif

AL=al2
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(PWPP_PEDALOG_DLL_MDB)  

LINUX_PKGCONFIG = \
	$(PWPP_PEDALOG_PC)  


RESGEN=resgen2
	
all: $(ASSEMBLY) $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

FILES = \
	BadResponseException.cs \
	DeviceBusyException.cs \
	FailedToOpenException.cs \
	Pedalog.cs \
	PedalogException.cs \
	Properties/AssemblyInfo.cs \
	Device.cs \
	Data.cs \
	Result.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	README \
	COPYING \
	pwpp.pedalog.pc.in 

REFERENCES =  \
	System

DLL_REFERENCES = 

CLEANFILES = $(PROGRAMFILES) $(LINUX_PKGCONFIG) 

include $(top_srcdir)/Makefile.include

PWPP_PEDALOG_PC = $(BUILD_DIR)/pwpp.pedalog.pc

$(eval $(call emit-deploy-wrapper,PWPP_PEDALOG_PC,pwpp.pedalog.pc))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'

$(ASSEMBLY_MDB): $(ASSEMBLY)

$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	mkdir -p $(shell dirname $(ASSEMBLY))
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
