require 'rake'
require 'open3'

swiplLocation = "D:\Program Files (x86)\swipl\bin\swipl.exe"
desc 'Generate Prolog file required for reference lookup.'
task :generate do
	command = "ExtractReferences.exe"
	stdin, stdout, stderr = Open3.popen3(command)

	if !(err = stderr.read).empty? then 
	        puts err
    else
    	result = stdout.read
    end
end

#This does not work because Prolog only returns true or false.  consider using ruby-prolog
desc '(NOT FUNCTIONAL) lists all references for a project'
task :list, [:project] do |t, args|
	puts args.project
	command = swiplLocation + ' -q -l .\Sample.pro projectReferences(\'' + args.project + "',X)";

	stdin, stdout, stderr = Open3.popen3(command)

	puts stdout.read
end

desc "Usage: rake 'reference[projectName,assemblyName]'.  Use lower case only.  Tells you if a project is referenced by another project somewhere in the chain (direct and transitive)"
task :reference, [:arg1, :arg2] do |t, args|

	#puts "Project Name : ";
	#projectName = STDIN.gets.chomp;

	#puts "Assembly Name : (without .dll)";
	#assemblyName = STDIN.gets.chomp;
	#puts "args: #{args}"
	#puts "in a string: " + "#{args.arg1} #{args.arg2}"
	#puts "out of string: " +  args.arg1 + args.arg2


	#sh("RunSample.bat #{args.arg1} #{args.arg2}")

	#TODO:  Considering adding more depth. 

	commands = [
		#swiplLocation + ' -q -l .\Sample.pro a(\'b\',\'c\')',
		#swiplLocation + ' -q -l .\Sample.pro a(\'' + args.arg1 + "','" + args.arg2 + "')",
		swiplLocation + ' -q -l .\Sample.pro projectReferences(\'' + args.arg1 + "','" + args.arg2 + "')",
		swiplLocation + ' -q -l .\Sample.pro transitiveReference(\'' + args.arg1 + "','" + args.arg2 + "')",
		swiplLocation + ' -q -l .\Sample.pro transitiveReferenceD1(\'' + args.arg1 + "','" + args.arg2 + "')",
		swiplLocation + ' -q -l .\Sample.pro transitiveReferenceD2(\'' + args.arg1 + "','" + args.arg2 + "')",
		swiplLocation + ' -q -l .\Sample.pro transitiveReferenceD3(\'' + args.arg1 + "','" + args.arg2 + "')",
		swiplLocation + ' -q -l .\Sample.pro transitiveReferenceD4(\'' + args.arg1 + "','" + args.arg2 + "')",
		swiplLocation + ' -q -l .\Sample.pro transitiveReferenceD5(\'' + args.arg1 + "','" + args.arg2 + "')",
		swiplLocation + ' -q -l .\Sample.pro transitiveReferenceD6(\'' + args.arg1 + "','" + args.arg2 + "')",
		swiplLocation + ' -q -l .\Sample.pro transitiveReferenceD7(\'' + args.arg1 + "','" + args.arg2 + "')",
		swiplLocation + ' -q -l .\Sample.pro transitiveReferenceD8(\'' + args.arg1 + "','" + args.arg2 + "')",
		swiplLocation + ' -q -l .\Sample.pro transitiveReferenceD9(\'' + args.arg1 + "','" + args.arg2 + "')",
		swiplLocation + ' -q -l .\Sample.pro transitiveReferenceD10(\'' + args.arg1 + "','" + args.arg2 + "')",
		swiplLocation + ' -q -l .\Sample.pro transitiveReferenceDN(\'' + args.arg1 + "','" + args.arg2 + "')"#this doesn't work.  Recursion broken
	]

	#array = [1, 2, 3, 4, 5, 6]
    #array.each { |x| puts x }

	foundReference = FALSE

    commands.each_with_index{ |x,index| 
    	#puts x
    	stdin, stdout, stderr = Open3.popen3(x)
		
	    if !(err = stderr.read).empty? then 
	        puts err
        else
        	result = stdout.read
        	if(result == "true\n") then
        		case index
        		when 0
        			puts "Yes. A direct reference was found."
        			foundReference = TRUE
        		when 1
        			puts "Yes.  There is a transitive reference"
        			foundReference = TRUE
        		when 2..11
        			puts "Yes. There is a transitive reference depth " + index.to_s
        			foundReference = TRUE
        		else
        			puts "Error.  this should never happen."
        		end
        	end
        	if(foundReference) then
        		break
        	end
	    end
    }

    if(!foundReference)
		puts "No reference found in the chain.  Or too deep in hierarchy to find."
	end
end